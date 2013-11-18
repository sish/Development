package com.example.oru.uppgift3;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.TextView;

public class Activity3 extends Activity {

	private TextView texten = null;
	   
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		//setContentView(R.layout.activity_activity1);
		
		texten = new TextView(this);
		texten.setText("Detta Šr aktivitet 3.");
        setContentView(texten);
	}

	static final private int MENU_ACTIVITY1 = Menu.FIRST;
	static final private int MENU_ACTIVITY2 = Menu.FIRST + 1;
	static final private int MENU_ACTIVITY3 = Menu.FIRST + 2;
	static final private int MENU_WEBBROWSER = Menu.FIRST + 3;
	
	MenuItem item_act1;
	MenuItem item_act2;
	MenuItem item_act3;
	MenuItem item_web;
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		// getMenuInflater().inflate(R.menu.activity1, menu);
		item_act1 = menu.add(Menu.NONE, MENU_ACTIVITY1, Menu.NONE, R.string.act1);
		item_act2 = menu.add(Menu.NONE, MENU_ACTIVITY2, Menu.NONE, R.string.act2);	
		item_act3 = menu.add(Menu.NONE, MENU_ACTIVITY3, Menu.NONE, R.string.act3);
		item_web = menu.add(Menu.NONE, MENU_WEBBROWSER, Menu.NONE, R.string.web);
		item_act3.setEnabled(false); // we are in this view, not sure why we want to go here again.
		return true;
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		int menyvalet = item.getItemId();
		switch (menyvalet) {
			case MENU_ACTIVITY1:
			{
				Intent the_act1_intent = new Intent(Activity3.this, Activity1.class);
				startActivity(the_act1_intent);
				break;
			}
			case MENU_ACTIVITY2:
			{
				Intent the_act2_intent = new Intent(Activity3.this, Activity2.class);
				startActivity(the_act2_intent);
				break;
			}
			case MENU_WEBBROWSER:
			{
				Intent intent = new Intent();
				intent.setAction(Intent.ACTION_VIEW);
				intent.setData(android.net.Uri.parse("http://basen.oru.se/kurser/android"));
				this.startActivity(intent);
				break;
			}	
			case MENU_ACTIVITY3:
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
}
