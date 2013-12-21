package joelsson.andreas.oruuppgift4;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.UnknownHostException;

import android.os.AsyncTask;
import android.os.Bundle;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends Activity {
	
	private static final int PORT = 2001;
	private static final String DEFAULT_HOST = "192.168.0.13";
	private TextView texten = null;
	private Button buttonSend = null;
	private Button buttonConnect = null;
	private Button buttonDisconnect = null;
	private EditText input = null;
	private ServerListener listener = null;
	private boolean Connected = false;
	private String username = null;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		texten = (TextView) findViewById(R.id.txt_input);
		texten.setText("");
		
		input = (EditText) findViewById(R.id.tbx_input);
		
		buttonSend = (Button) findViewById(R.id.btn_send);
		buttonSend.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                doSend();
            }
        });
        
        buttonConnect = (Button) findViewById(R.id.btn_connect);
        buttonConnect.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                doConnect();
            }
        });
        
        buttonDisconnect = (Button) findViewById(R.id.btn_disconnect);
        buttonDisconnect.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                doDisconnect();
            }
        });
        
        updateButtonEnabled();
        
    
	    final AlertDialog.Builder alert = new AlertDialog.Builder(this);
	    final EditText input = new EditText(this);
	    alert.setView(input);
	    alert.setTitle("Ange användarnamn:");
	    alert.setPositiveButton("Ok", new DialogInterface.OnClickListener() {
	        public void onClick(DialogInterface dialog, int whichButton) {
	            username = input.getText().toString();
	        }
	    });
	    alert.show();
        
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}
	
	private void updateButtonEnabled()
	{
		buttonConnect.setEnabled(!isConnected());
		buttonDisconnect.setEnabled(isConnected());
		buttonSend.setEnabled(isConnected());
	}
	
	private void doSend()
	{
		if( null != listener ) {
			listener.SendMessage(input.getText().toString());
			input.setText("");
		}
	}
	
	private void doConnect()
	{
		Log.v("doConnect", "Connecting");
		if( 0 == input.getText().toString().length() ) {
			texten.append(">> Connecting to default host...\n");
			listener = new ServerListener(DEFAULT_HOST, PORT);
		} else {
			String host = input.getText().toString();
			texten.append(">> Connecting to " + host + "...\n");
			listener = new ServerListener(host, PORT);
			input.setText("");
		}
		listener.execute(username);
		Connected = true;
		updateButtonEnabled();
	}
	
	private void doDisconnect()
	{
		texten.append(">> Disconnecting...\n");
		//Connected = false;
		listener.SendMessage("LOGOUT");
		listener.Terminate();
		listener.cancel(true);
		listener = null;
		Connected = false;
		updateButtonEnabled();
	}
	
	private boolean isConnected()
	{
		return Connected;
	}
	
	private class ServerListener extends AsyncTask<String, String, Void> {
		
		private String Host;
		private int Port;
		PrintWriter to_server = null;
		BufferedReader from_server = null;
		Socket socket = null;
		
		public ServerListener(String host, int port)
		{
			this.Host = host;
			this.Port = port;
		}
		
		public void SendMessage(String message)
		{
			if(null != to_server)
			{
				to_server.println(message);
			}
		}
		
		protected Void doInBackground(String... params) {
	    	 
			 
			try {
				socket = new Socket(Host, Port);
				to_server = new PrintWriter(new BufferedWriter(new OutputStreamWriter(socket.getOutputStream())), true);
				from_server = new BufferedReader(new InputStreamReader(socket.getInputStream()));
				if( 0 < params.length )
				{
					SendMessage("LOGIN " + params[0]);
				}
				while (true == isConnected()) {
		        	 String line_from_server;
		 			try {
		 				line_from_server = from_server.readLine();
		 				Log.d("ServerListener", "Line:> " + line_from_server);
		 				if (line_from_server == null) {
		 					publishProgress("Fick inga data från servern");
		 					Connected = false;
		 				}
		 				else {
		 					publishProgress(line_from_server);
		 				}
		 			}
		 			catch (IOException e) {
		 				publishProgress("Fel vid mottagning från servern");
		 				Log.d("ServerListener", "Error: " + e.getMessage());
		 				Connected = false;
		 			}
		         }
				Log.d("ServerListener", "After while.");
			} catch (UnknownHostException e1) {
				
				//texten.append(e1.getMessage());
				publishProgress(e1.getMessage());
				//e1.printStackTrace();
				Connected = false;
			} catch (IOException e1) {
				// TODO Auto-generated catch block
				publishProgress(e1.getMessage());
				Connected = false;
			}
			Log.d("ServerListener", "Before null return.");
			return null;
	     }
		
		protected void Terminate()
		{
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
				texten.append(e.getMessage());
			}
		}
		
		protected void onCancelled ()
		{
			texten.append("Cancelling\n");
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
				texten.append(e.getMessage());
			}
		}

	     protected void onProgressUpdate(String... message) {
	    	 for(int i = 0; i < message.length; i++) {
	    		 texten.append(message[i] + "\n");
	    	 }
	     }


	 }
	

}
