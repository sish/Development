package andreas.joelsson.oruuppgift5;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.UnknownHostException;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.regex.Matcher;

import andreas.joelsson.oruuppgift5.IZombieBaseC.HandleRetValue;
import andreas.joelsson.oruuppgift5.IZombieBaseC.ZombieType;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.location.LocationProvider;
import android.os.AsyncTask;
import android.os.Bundle;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.Intent;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;

public class MainActivity extends Activity implements IMainActivityAccess {

	private static final int PORT = 2002;
	//private static final String DEFAULT_HOST = "192.168.0.13";
	private static final String DEFAULT_HOST = "basen.oru.se";
	private ServerListener listener = null;
	private ZombiePlayerC Player = null;
	
	/// ZoomLevels
	private enum ZoomLevels 
	{
		ZOOM_MIN,
		ZOOM_50,
		ZOOM_100,
		ZOOM_250,
		ZOOM_1000,
		ZOOM_2500,
		ZOOM_10000,
		ZOOM_MAX
	};
	private ZoomLevels CurrentZoom = ZoomLevels.ZOOM_100;
		
	/// GPS
    private LocationManager location_manager;
    private LocationListener location_listener;
    private DecimalFormat dec = new DecimalFormat("0.0000");
	
    /// Menu
    static final private int MENU_CONNECT = Menu.FIRST;
	static final private int MENU_REGISTER = Menu.FIRST + 1;
	static final private int MENU_LOGIN = Menu.FIRST + 2;
	static final private int MENU_LOGOUT = Menu.FIRST + 3;
	static final private int MENU_ZOOMIN = Menu.FIRST + 4;
	static final private int MENU_ZOOMOUT = Menu.FIRST + 5;
	
	MenuItem item_connect;
	MenuItem item_register;
	MenuItem item_login;
	MenuItem item_logout;
	MenuItem item_zoomin;
	MenuItem item_zoomout;
	
	/// Activities
	Intent the_login_intent = null;
	Intent the_register_intent = null;
	
	/// Graphic view
	private ZombieView the_view;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		Log.v("MainActivity", "onCreate(" + savedInstanceState + ")");
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		the_view = (ZombieView)findViewById(R.id.zombieview);
		the_view.SetAccess(this);
		
		if( null == Static.Server ) {
			listener = new ServerListener(DEFAULT_HOST, PORT);
			Static.Server = listener;
		}
		if( null == Static.Player ) {
			Player = new ZombiePlayerC(this);
			Static.Player = Player;
			RegisterProcedure(Static.Player);
		}
		/// GPS
		location_manager = (LocationManager) this.getSystemService(Context.LOCATION_SERVICE);
	        
        location_listener = new LocationListener() {
            @Override
            public void onLocationChanged(Location location) {
            	Log.v("MainActivity", "onLocationChanged(" + location + ")");
                double longitude = location.getLongitude();
                double latitude = location.getLatitude();
                //double accuracy = location.getAccuracy();
                //double altitude= location.getAltitude();
                Static.Player.UpdatePosition(new Coordinate(latitude, longitude));
            }
            
            @Override
            public void onProviderDisabled(String provider) {
            	Log.v("MainActivity", "onProviderDisabled(" + provider + ")");
                 Log.d("MainActivity", "Location provider has been disabled.");
            }

            @Override
            public void onProviderEnabled(String provider) {
            	Log.v("MainActivity", "onProviderEnabled(" + provider + ")");
                 Log.d("MainActivity", "Good news! Location provider has been enabled.");
            }

            @Override
            public void onStatusChanged(String provider, int status,
                    Bundle extras) {
            	Log.v("MainActivity", "onStatusChanged(" + provider + ", " + status + ", " + extras + ")");
                if (status == LocationProvider.OUT_OF_SERVICE)
                    Log.e("MainActivity", "GPS status changed to OUT_OF_SERVICE.");
                else if (status == LocationProvider.TEMPORARILY_UNAVAILABLE)
                    Log.e("MainActivity", "GPS status changed to TEMPORARILY_UNAVAILABLE.");
                else if (status == LocationProvider.AVAILABLE)
                    Log.e("MainActivity", "Good news! GPS status changed to AVAILABLE.");
            }
        };
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		Log.v("MainActivity", "onCreateOptionsMenu(" + menu + ")");
		// Inflate the menu; this adds items to the action bar if it is present.
//		getMenuInflater().inflate(R.menu.main, menu);
		item_zoomin = menu.add(Menu.NONE, MENU_ZOOMIN, Menu.NONE, R.string.zoomin);
		item_zoomout = menu.add(Menu.NONE, MENU_ZOOMOUT, Menu.NONE, R.string.zoomout);
		item_connect = menu.add(Menu.NONE, MENU_CONNECT, Menu.NONE, R.string.connect);
		item_register = menu.add(Menu.NONE, MENU_REGISTER, Menu.NONE, R.string.register);
		item_login = menu.add(Menu.NONE, MENU_LOGIN, Menu.NONE, R.string.login);	
		item_logout = menu.add(Menu.NONE, MENU_LOGOUT, Menu.NONE, R.string.logout);
		SetMenuEnabled();
		return true;
	}
	
	@Override
	public void SetMenuEnabled()
	{
		Log.v("MainActivity", "SetMenuEnabled(Connect : " + Static.Connected + ", LoggeIn: " + Static.Player.IsLoggedIn() + ")");
		item_logout.setEnabled(true == Static.Connected && true == Static.Player.IsLoggedIn());
		item_register.setEnabled(true == Static.Connected);
		item_login.setEnabled(true == Static.Connected && true != Static.Player.IsLoggedIn());
		item_connect.setEnabled(true != Static.Connected || true == Static.Player.IsLoggedIn());
		item_connect.setTitle(true == Static.Connected ? R.string.turnme : R.string.connect);
		item_zoomin.setVisible(true == Static.Connected);
		item_zoomout.setVisible(true == Static.Connected);
		item_zoomin.setEnabled(ZoomLevels.ZOOM_50 != CurrentZoom);
		item_zoomout.setEnabled(ZoomLevels.ZOOM_10000 != CurrentZoom);
		Log.d("MainActivity", "SetMenuEnabled - logout: " + item_logout.isEnabled());
		Log.d("MainActivity", "SetMenuEnabled - login: " + item_login.isEnabled());
		Log.d("MainActivity", "SetMenuEnabled - register: " + item_register.isEnabled());
		Log.d("MainActivity", "SetMenuEnabled - connect / turnme: " + item_connect.isEnabled());
		Log.d("MainActivity", "SetMenuEnabled - zoomin: " + item_zoomin.isEnabled());
		Log.d("MainActivity", "SetMenuEnabled - zoomout: " + item_zoomout.isEnabled());
		Log.d("MainActivity", "SetMenuVisible - zoomin: " + item_zoomin.isVisible());
		Log.d("MainActivity", "SetMenuVisible - zoomout: " + item_zoomout.isVisible());
		//TODO remove me from here
//        if( true != Static.Connected) {
//        	doConnect();
//        	try {
//				Thread.sleep(2000);
//			} catch (InterruptedException e) {
//				// TODO Auto-generated catch block
//				e.printStackTrace();
//			}
//        	Static.Player.SendLogin("scrier", "test");
//        }
        //TODO to here
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		int menyvalet = item.getItemId();
		switch (menyvalet) {
			case MENU_CONNECT:
			{
				if( true != Static.Connected ) {
					doConnect();
				} else {
					//TODO handle disconnect and connect parts.
					//doDisConnect(); 
					doTurn();
				}
				break;
			}
			case MENU_REGISTER:
			{
				doRegister();
				break;
			}
			case MENU_LOGIN:
			{
				doLogin();
				break;
			}
			case MENU_LOGOUT:
			{
				doLogout();
				break;
			}	
			case MENU_ZOOMIN:
			{
				doZoomIn();
				break;
			}	
			case MENU_ZOOMOUT:
			{
				doZoomOut();
				break;
			}	
			default:
			{
				AlertDialog.Builder builder = new AlertDialog.Builder(this);
				builder.setTitle("Hi there!");
				builder.setMessage("Reached default/current state in menu choice, you selected the unselectable.");
				
				builder.setNeutralButton("Ok", null);
				builder.show();
				break;
			}
		}
		return true;
	}
	
	@Override
    protected void onPause() {
		Log.v("MainActivity", "onPause()");
        super.onPause();
        location_manager.removeUpdates(location_listener);
        the_view.pause();
    }

    @Override
    protected void onResume() {
    	Log.v("MainActivity", "onResume()");
        super.onResume();
        the_view.resume();
        try {
            // Register the listener with the Location Manager to receive
            // location updates
            location_manager.requestLocationUpdates(LocationManager.GPS_PROVIDER, 0, 0, location_listener);
        }
        catch (Exception e) {
            Log.e("MainActivity", "Couldn't use the GPS: " + e + ", " + e.getMessage());
        }
        
    }
	
	private void doRegister()
	{
		Log.v("MainActivity", "doRegister()");
		if( null == the_register_intent ) {
			the_register_intent = new Intent(MainActivity.this, RegisterActivity.class);
			the_register_intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_SINGLE_TOP);
		}
		startActivity(the_register_intent);
	}
	
	private void doLogin()
	{
		Log.v("MainActivity", "doLogin()");
		if( null == the_login_intent ) {
			the_login_intent = new Intent(MainActivity.this, LoginActivity.class);
			the_login_intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_SINGLE_TOP);
		}
		startActivity(the_login_intent);
		SetMenuEnabled();
	}
	
	private void doLogout()
	{
		Log.v("MainActivity", "doLogout()");
		Static.Player.SendLogout();
		SetMenuEnabled();
	}
	
	private void doConnect()
	{
		Log.v("MainActivity", "doConnect()");
		if( null == Static.Server ) {
			listener = new ServerListener(DEFAULT_HOST, PORT);
			Static.Server = listener;
		}
		Static.Connected = true;
		Static.Server.execute();
		SetMenuEnabled();
	}
	
	private void doTurn()
	{
		Log.v("MainActivity", "doTurn()");
		Static.Player.DebugTurnMe(Static.Player.IsHuman() ? ZombieType.ZOMBIE : ZombieType.HUMAN);
	}
	
	private void doZoomIn()
	{
		Log.v("MainActivity", "doZoomIn()");
		switch( CurrentZoom ) {
			case ZOOM_100: {
				Static.Player.UpdateVisibility(50);
				CurrentZoom = ZoomLevels.ZOOM_50;
				break;
			} 
			case ZOOM_250: {
				Static.Player.UpdateVisibility(100);
				CurrentZoom = ZoomLevels.ZOOM_100;
				break;
			} 
			case ZOOM_1000: {
				Static.Player.UpdateVisibility(250);
				CurrentZoom = ZoomLevels.ZOOM_250;
				break;
			} 
			case ZOOM_2500: {
				Static.Player.UpdateVisibility(1000);
				CurrentZoom = ZoomLevels.ZOOM_1000;
				break;
			} 
			case ZOOM_10000: {
				Static.Player.UpdateVisibility(2500);
				CurrentZoom = ZoomLevels.ZOOM_2500;
				break;
			}
			case ZOOM_50:
			case ZOOM_MIN:
			case ZOOM_MAX:
			default:
			{
				break;
			}
		}
		SetMenuEnabled();
	}
	
	private void doZoomOut()
	{
		Log.v("MainActivity", "doZoomOut()");
		switch( CurrentZoom ) {
			case ZOOM_50: {
				Static.Player.UpdateVisibility(100);
				CurrentZoom = ZoomLevels.ZOOM_100;
			}
			case ZOOM_100: {
				Static.Player.UpdateVisibility(250);
				CurrentZoom = ZoomLevels.ZOOM_250;
				break;
			} 
			case ZOOM_250: {
				Static.Player.UpdateVisibility(1000);
				CurrentZoom = ZoomLevels.ZOOM_1000;
				break;
			} 
			case ZOOM_1000: {
				Static.Player.UpdateVisibility(2500);
				CurrentZoom = ZoomLevels.ZOOM_2500;
				break;
			} 
			case ZOOM_2500: {
				Static.Player.UpdateVisibility(10000);
				CurrentZoom = ZoomLevels.ZOOM_10000;
				break;
			} 
			case ZOOM_10000:
			case ZOOM_MIN:
			case ZOOM_MAX:
			default:
			{
				break;
			}
		}
		SetMenuEnabled();
	}
	
	// Removed due to not being able to connect again after disconnect.
//	private void doDisConnect()
//	{
//		Log.v("MainActivity", "doDisConnect()");
//		Static.Server.Terminate();
//		Static.Server.cancel(true);
//		Static.Server = null;
//		listener = null;
//		Static.Connected = false;
//		SetMenuEnabled();
//	}
	
	public class ServerListener extends AsyncTask<String, String, Void> {
		
		private String Host;
		private int Port;
		PrintWriter to_server = null;
		BufferedReader from_server = null;
		Socket socket = null;
		
		public ServerListener(String host, int port)
		{
			Log.v("ServerListener", "ServerListener(" + host + ", " + port + ")");
			this.Host = host;
			this.Port = port;
		}
		
		public void SendMessage(String message)
		{
			Log.v("ServerListener", "SendMessage(" + message + ")");
			if(null != to_server)
			{
				to_server.println(message);
			}
		}
		
		protected Void doInBackground(String... params) {
			Log.v("ServerListener", "doInBackground()");
			try {
				socket = new Socket(Host, Port);
				to_server = new PrintWriter(new BufferedWriter(new OutputStreamWriter(socket.getOutputStream())), true);
				from_server = new BufferedReader(new InputStreamReader(socket.getInputStream()));
				while (true == IsConnected()) {
		        	 String line_from_server;
		 			try {
		 				line_from_server = from_server.readLine();
		 				Log.d("ServerListener", "Line:> " + line_from_server);
		 				if (line_from_server == null) {
		 					publishProgress("Fick inga data från servern");
		 					Static.Connected = false;
		 				}
		 				else {
		 					publishProgress(line_from_server);
		 				}
		 			}
		 			catch (IOException e) {
		 				publishProgress("Fel vid mottagning från servern");
		 				Log.e("ServerListener", "Error: " + e.getMessage());
		 				Static.Connected = false;
		 			}
		         }
				Log.d("ServerListener", "After while.");
			} catch (UnknownHostException e1) {
				
				//texten.append(e1.getMessage());
				publishProgress(e1.getMessage());
				//e1.printStackTrace();
				Static.Connected = false;
			} catch (IOException e1) {
				// TODO Auto-generated catch block
				publishProgress(e1.getMessage());
				Static.Connected = false;
			}
			Log.d("ServerListener", "Before null return.");
			return null;
	     }
		
		protected void Terminate()
		{
			Log.v("ServerListener", "Terminate()");
			try{
				to_server.close();
				to_server = null;
				Log.d("ServerListener", "Terminate: to_server null.");
				from_server.close();
				from_server = null;
				Log.d("ServerListener", "Terminate: from_server null.");
				socket.close();
				socket = null;
				Log.d("ServerListener", "Terminate: socket null.");
			} catch(Exception e) {
				Log.e("ServerListener", "Terminate, Exception: " + e.getMessage());
			}
		}
		
		protected void onCancelled ()
		{
			Log.v("ServerListener", "onCancelled()");
			try {
				if( null != to_server ) {
					to_server.close();
					to_server = null;
				}
				if( null != from_server ) {
					from_server.close();
					from_server = null;
				}
				if( null != socket ) {
					socket.close();
					socket = null;
				}
			} catch(Exception e) {
				Log.e("ServerListener", "onCancelled, Exception: " + e.getMessage());
			}
		}

	     protected void onProgressUpdate(String... message) {
	    	 Log.v("ServerListener", "onProgressUpdate()");
	    	 for(int i = 0; i < message.length; i++) {
	    		 HandleServerMessage(message[i]);
	    	 }
	     }
	 }

	@Override
	public void SendMessage(String message) {
		Log.v("MainActivity", "SendMessage(" + message + ")");
		if( null != listener ) {
			listener.SendMessage(message);
		}
	}
	
	public void HandleServerMessage(String message) {
		Log.v("MainActivity", "HandleServerMessage(" + message + ")");
		try
		{
			List<IZombieBaseC> toRemove = new ArrayList<IZombieBaseC>();
			HandleRetValue retValue = null;
			// Send message to active procedures.
			Log.d("MainActivity", "HandleServerMessage: No of Procedures: " + Static.procedures.size());
			for( IZombieBaseC procedure : Static.procedures ) {
				retValue = procedure.HandleInMessage(message);
				if(IZombieBaseC.COMPLETED == retValue.CurrentStatus ||
						IZombieBaseC.ABORTED == retValue.CurrentStatus) {
					toRemove.add(procedure);
				}
				if(true == retValue.MessageHandled) {
					Log.d("MainActivity", "HandleServerMessage: Break from loop.");
					break;
				}
			}
			// Check and handle unhandled messages.
			Log.d("MainActivity", "if( null != retValue(" + (null != retValue) + ") && false == retValue.MessageHandled(" + (false == retValue.MessageHandled) + " )");
			if( null != retValue && false == retValue.MessageHandled ) {
				Log.d("MainActivity", "if( null != retValue && false == retValue.MessageHandled )");
				Matcher match = ZombiePlayerC.P_ASYNC_REGEX.matcher(message);
				if( true == match.find() && 5 == match.groupCount() && match.group(1).equals("PLAYER") ) {
					// ASYNC PLAYER olle HUMAN 30.1 30.1 
					String Name = match.group(2);
					ZombieType Type = (true == match.group(3).equals(ZombieClientC.S_HUMAN) ) ? ZombieType.HUMAN : ZombieType.ZOMBIE;
					Double Latitude = Double.parseDouble(match.group(4));
					Double Longitude = Double.parseDouble(match.group(5));
					RegisterProcedure(new ZombieClientC(Name, Latitude, Longitude, Type));
				} else {
					Log.e("MainActivity", "true == match.find() && 6 == match.groupCount(" + (5 == match.groupCount())+ ", [" + match.groupCount() + "]) && match.group(2).equals(\"PLAYER\") [" + match.group(1) + "]");
				}
			}
			// Unregister procedures that needs to be removed.
			for( IZombieBaseC remove : toRemove ) {
				Log.d("MainActivity", "for( IZombieBaseC remove : toRemove )");
				UnRegisterProcedure(remove);
			}
			toRemove.clear();
		}
		catch (Exception ex)
		{
			//TODO better handling for known issues, perhaps an exception handler.
			Log.e("MainActivity", "HandleServerMessage. Exception caught: " + ex.getMessage() + ".");
		}
	}
	
	@Override
	public boolean DoesPlayerExist(String username) {
		Log.v("MainActivity", "DoesPlayerExist(" + username + ")");
		boolean retValue = false;
		for( IZombieBaseC procedure : Static.procedures ) {
			if( procedure.GetName().equals(username) ) {
				retValue = true;
				break;
			}
		}
		return retValue;
	}
	
	@Override
	public boolean RegisterProcedure(IZombieBaseC proc)
	{
		Log.v("MainActivity", "RegisterProcedure(" + proc + ")");
		return Static.procedures.add(proc);
	}
	
	protected boolean UnRegisterProcedure(IZombieBaseC proc)
	{
		Log.v("MainActivity", "UnRegisterProcedure(" + proc + ")");
		return Static.procedures.remove(proc);
	}
	
	@Override
	public boolean IsConnected()
	{
		return Static.Connected;
	}

}
