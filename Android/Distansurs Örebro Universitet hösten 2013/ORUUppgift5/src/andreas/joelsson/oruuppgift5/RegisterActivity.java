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

public class RegisterActivity extends Activity implements IMessageResponse {

	private Button buttonLogin = null;
	private Button buttonCancel = null;
	private EditText user = null;
	private EditText password = null;
	private EditText verifyPassword = null;
	
	Intent the_main_intent = null;
	Intent the_login_intent = null;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		Log.v("RegisterActivity", "onCreate()");
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_register);
		
		user = (EditText) findViewById(R.id.tbx_username);
		password = (EditText) findViewById(R.id.tbx_password);
		verifyPassword = (EditText) findViewById(R.id.tbx_password_verify);
		
		buttonLogin = (Button) findViewById(R.id.btn_register);
		buttonLogin.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
            	doRegister();
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
		Log.v("RegisterActivity", "onCreateOptionsMenu()");
		getMenuInflater().inflate(R.menu.register, menu);
		return true;
	}
	
	void doRegister()
	{
		Log.v("RegisterActivity", "doRegister()");
		if( 0 == user.getText().length() ) {
			AlertDialog.Builder builder = new AlertDialog.Builder(this);
			builder.setTitle("Invalid Register.");
			builder.setMessage("Username cannot be empty.");
			
			builder.setNeutralButton("Ok", null);
			builder.show();
		} else if ( 0 == password.getText().length() ) {
			AlertDialog.Builder builder = new AlertDialog.Builder(this);
			builder.setTitle("Invalid Register.");
			builder.setMessage("Password cannot be empty.");
			
			builder.setNeutralButton("Ok", null);
			builder.show();
		} else if ( true != password.getText().toString().equals(verifyPassword.getText().toString()) ) {
			AlertDialog.Builder builder = new AlertDialog.Builder(this);
			builder.setTitle("Invalid Register.");
			builder.setMessage("Passwords did not match.");
			
			builder.setNeutralButton("Ok", null);
			builder.show();
		} else if( null != Static.Player ) {
			Static.Player.SendRegister(user.getText().toString(), password.getText().toString(), this);
		}
	}
	
	void doCancel()
	{
		Log.v("RegisterActivity", "doCancel()");
		if( null == the_main_intent ) {
			the_main_intent = new Intent(RegisterActivity.this, MainActivity.class);
			the_main_intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_SINGLE_TOP);
		}
		startActivity(the_main_intent);
	}

	@Override
	public void MessageResponse(COMMANDS command, int counter, String response) {
		// TODO Auto-generated method stub
		Log.v("RegisterActivity", "MessageResponse(" + command + ", " + counter + ", " + response + ")");
		if( COMMANDS.E_REGISTER == command ) {
			if( response.contains("REGISTERED") ) {
				if( null == the_login_intent ) {
					the_login_intent = new Intent(RegisterActivity.this, LoginActivity.class);
					the_login_intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_SINGLE_TOP);
				}
				startActivity(the_login_intent);
			} else {
				AlertDialog.Builder builder = new AlertDialog.Builder(this);
				builder.setTitle("Failure to register.");
				builder.setMessage("Received error from server: " + response + ".");
				
				builder.setNeutralButton("Ok", null);
				builder.show();
			}
		}
	}

}
