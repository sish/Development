package andreas.joelsson.oruuppgift5;

import andreas.joelsson.oruuppgift5.ZombiePlayerC.COMMANDS;
import android.os.Bundle;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.Intent;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class LoginActivity extends Activity implements IMessageResponse {

	private Button buttonLogin = null;
	private Button buttonCancel = null;
	private EditText user = null;
	private EditText password = null;
	
	Intent the_main_intent = null;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_login);
		
		user = (EditText) findViewById(R.id.tbx_username);
		password = (EditText) findViewById(R.id.tbx_password);
		
		buttonLogin = (Button) findViewById(R.id.btn_login);
		buttonLogin.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                doLogin();
            }
        });
		
		buttonCancel = (Button) findViewById(R.id.btn_cancel);
		buttonCancel.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                doCancel();
            }
        });
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.login, menu);
		return true;
	}
	
	private void doLogin()
	{
		Log.v("LoginActivity", "doLogin()");
		if( null != Static.Player ) {
			if( 0 < user.getText().length() && 0 < password.getText().length() ) {
				Static.Player.SendLogin(user.getText().toString(), password.getText().toString(), this);
			}
		}
	}
	
	private void doCancel()
	{
		Log.v("LoginActivity", "doCancel()");
		if( null == the_main_intent ) {
			the_main_intent = new Intent(LoginActivity.this, MainActivity.class);
			the_main_intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_SINGLE_TOP);
		}
		startActivity(the_main_intent);
	}

	@Override
	public void MessageResponse(COMMANDS command, int counter, String response) {
		Log.v("LoginActivity", "MessageResponse(" + command + ", " + counter + ", " + response + ")");
		if( COMMANDS.E_LOGIN == command ) {
			if( response.contains("WELCOME") ) {
				if( null == the_main_intent ) {
					the_main_intent = new Intent(LoginActivity.this, MainActivity.class);
					the_main_intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_SINGLE_TOP);
				}
				startActivity(the_main_intent);
			} else {
				AlertDialog.Builder builder = new AlertDialog.Builder(this);
				builder.setTitle("Failure to login.");
				builder.setMessage("Received error from server: " + response + ".");
				
				builder.setNeutralButton("Ok", null);
				builder.show();
			}
		}
	}

}
