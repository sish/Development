package com.example.oru.uppgift2;

import android.os.Bundle;
import android.app.Activity;
import android.text.format.Time;
import android.view.Menu;
import android.widget.TextView;

public class MainActivity extends Activity {
	
	private TextView texten = null;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		texten = new TextView(this);
		texten.setText("");
        setContentView(texten);

        print("onCreate");
	}
	
	@Override
	protected void onStart() {
		super.onStart();
		
		print("onStart");
	}
    
	@Override
    protected void onRestart() {
		super.onRestart();
		
		print("onRestart");
	}

	@Override
    protected void onResume() {
    	super.onResume();
    	
    	print("onResume");
    }

	@Override
    protected void onPause() {
		super.onPause();
		
		print("onPause");
	}

	@Override
    protected void onStop() {
		super.onStop();
		
		print("onStop");
	}

	@Override
    protected void onDestroy() {
    	super.onDestroy();
    	
    	print("onDestroy");
    }
	
	@Override
	public void onSaveInstanceState(Bundle savedInstanceState) {
	  super.onSaveInstanceState(savedInstanceState);
	  // Save UI state changes to the savedInstanceState.
	  // This bundle will be passed to onCreate if the process is
	  // killed and restarted.
	  print("onSaveInstanceState");
	  savedInstanceState.putString("SavedTextView", texten.getText().toString());
	  // etc.
	}
	
	@Override
	public void onRestoreInstanceState(Bundle savedInstanceState) {
	  super.onRestoreInstanceState(savedInstanceState);
	  // Restore UI state from the savedInstanceState.
	  // This bundle has also been passed to onCreate.
	  texten.setText(savedInstanceState.getString("SavedTextView"));
	  print("onRestoreInstanceState");
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		print("onCreateOptionsMenu");
		return true;
	}
	
	private void print(String text) {
        Time now = new Time();
        now.setToNow();
        String timeString = now.format("%H:%M:%S");
        String line = timeString + ": " + text + "\n";
        texten.setText(texten.getText() + line);
        texten.invalidate();
        texten.postInvalidate();
    }

}
