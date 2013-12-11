package andreas.joelsson.oruuppgift5;

import java.util.Timer;
import java.util.TimerTask;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.util.AttributeSet;
import android.util.Log;
import android.view.View;

public class ZombieView extends View { 
	
	private int width_pixels;
	private int height_pixels;
	private Paint p = null;
    // Measured in pixels
    private int ball_radius = 10;
    
    private Timer the_ticker;
    
    private IMainActivityAccess the_access;
	
    public ZombieView(Context context) {
        super(context);
    }
        
    public ZombieView(Context context, AttributeSet attrs) {
        super(context, attrs);
    }
    
    public void SetAccess(IMainActivityAccess access) {
    	the_access = access;
    	Static.ShowDebug = 50;
    }
    
    @Override
    protected void onSizeChanged(int w, int h, int oldw, int oldh) {
	    super.onSizeChanged(w, h, oldw, oldh);
	    width_pixels = w;
	    height_pixels = h;
    }
    
    @Override
    protected void onDraw(Canvas canvas) {
	    super.onDraw(canvas);
	    Static.ShowDebug--;
	    if( null == p ) {
	    	p = new Paint();
	    }
	    canvas.drawColor(Color.WHITE);
	    int w = this.getWidth();
	    int h = this.getHeight();
	    
	    // The player is green when human, red when zombie, black when not logged in
	    if( true != Static.Player.IsLoggedIn() ) {
	    	p.setColor(Color.BLACK);
	    } else if (true == Static.Player.IsHuman()) {
	        p.setColor(Color.GREEN);
	    } else {
	        p.setColor(Color.RED);
	    }
	    if( true == the_access.IsConnected() ) {
	    	canvas.drawCircle(w / 2, h / 2, ball_radius, p); // center always for player
		    // A crosshair at the middle of the screen
		    float crosswidth = Math.min(w, h) * 0.05f;
		    canvas.drawLine(w * 0.5f - crosswidth, h * 0.5f, w * 0.5f + crosswidth, h * 0.5f, p);
		    canvas.drawLine(w * 0.5f, h * 0.5f - crosswidth, w * 0.5f, h * 0.5f + crosswidth, p);
	    }
	    
	    p.setColor(Color.RED);
	    canvas.drawText("w = " + w + " (" + width_pixels + ")" +
	                    ", h = " + h + " (" + height_pixels + ")",
	                    20.0f, 40.0f, p);
	    	    
	    if( true != the_access.IsConnected() ) {
	    	canvas.drawText("No Connection to Server",
                    20.0f, h - 5.0f, p);
	    } else if ( true != Static.Player.IsLoggedIn() ) {
	    	canvas.drawText("Disconnected",
	                    20.0f, h - 5.0f, p);
	    } else {
	    	p.setColor(Color.BLUE);
	    	float crossheight = Math.min(w, h) * 0.05f;
		    canvas.drawLine(w * 0.95f, h * 0.95f - crossheight, w * 0.95f, h * 0.95f + crossheight, p);
		    canvas.drawLine(w * 0.45f, h * 0.95f - crossheight, w * 0.45f, h * 0.95f + crossheight, p);
		    canvas.drawLine(w * 0.45f, h * 0.95f, w * 0.95f, h * 0.95f, p);
		    canvas.drawText("Scale: " + Static.Player.GetVisibility() + "m", 0.47f * w, 0.94f * h, p);
	    }
	    
	    //Log.d("ZombieView", "Size in view: " + the_access.GetProcedures().size());
	    for ( IZombieBaseC procedure : Static.procedures ) {
	    	//Log.d("ZombieView", "if( true != " + procedure.IsPlayer() + " && true == " + Static.Player.IsWithinRange(procedure.GetPosition(), Static.Player.GetVisibility()));
	    	if( true != procedure.IsPlayer() && true == Static.Player.IsWithinRange(procedure.GetPosition(), Static.Player.GetVisibility())) {
	    		float cx = Static.Player.GetPosition().getLongitudeDeltaInMeters(procedure.GetPosition());
	    		float cy = Static.Player.GetPosition().getLatitudeDeltaInMeters(procedure.GetPosition());
	    		if( 0 == Static.ShowDebug ) {
	    			Log.d("ZombieView", "Player: " + Static.Player.GetPosition());
	    			Log.d("ZombieView", procedure.GetName() + ": " + procedure.GetPosition());
	    			Log.d("ZombieView", "Distance: " + Static.Player.GetPosition().getDistance(procedure.GetPosition(), Coordinate.UNIT_METERS));
	    			Log.d("ZombieView", "Angle: " + Math.toDegrees(Static.Player.GetPosition().getAngle(procedure.GetPosition())));
	    			Log.d("ZombieView", "meters - cx: " + cx + " / cy: " + cy);
	    		}
	    		cx /= Static.Player.GetVisibility();
	    		cy /= Static.Player.GetVisibility();
	    		if( 0 == Static.ShowDebug ) {
	    			Log.d("ZombieView", "divided by visibility - cx: " + cx + " / cy: " + cy);
	    		}
	    		cx *= w;
	    		cy *= h;
	    		if( 0 == Static.ShowDebug ) {
	    			Log.d("ZombieView", "times w and h - cx: " + cx + " / cy: " + cy);
	    		}
	    		cx += w * 0.5;
	    		cy += h * 0.5;
	    		if( 0 == Static.ShowDebug ) {
	    			Log.d("ZombieView", "from center - cx: " + cx + " / cy: " + cy);
	    		}
	    		p.setColor(procedure.IsZombie() ? Color.RED : Color.GREEN);
	    		if( 0 == Static.ShowDebug ) {
	    			Log.d("ZombieView", "canvas.drawCircle(" + cx + ", " + cy + ", 5.0f, " + p + ");");
	    		}
	    		canvas.drawCircle(cx, cy, 5.0f, p);
	    		canvas.drawText(procedure.GetName(), cx, cy - 5, p);
	    	}
	    }
	    if( 0 >= Static.ShowDebug ) {
	    	Static.ShowDebug = 500;
	    }
	} // onDraw
    
    // Called when the app is visible(possibly: again). We should start moving.
    public void resume() {
        the_ticker = new Timer();
        TimerTask task = new TimerTask() {
                @Override
                    public void run() {
                    update_simulation();
                    // We get CalledFromWrongThreadException if we just just call invalidate().
                    // It must be done in the right thread!
                    Runnable r = new Runnable() {
                            @Override
                                public void run() {
                                invalidate();
                            }
                        };
                    getHandler().post(r);
                }
            };
        // Give it a full second to set things up, before we start ticking
        // (It crashed with java.lang.NullPointerException when starting after 30 ms, but worked with 40.)
        the_ticker.schedule(task, 5000, 10);
    } // resume

    // Called when the app has been hidden. We should stop moving.
    public void pause() {
        nanos_when_paused = java.lang.System.nanoTime(); 
        the_ticker.cancel();
        the_ticker = null;
    }
    
    // -1 is not guaranteed to never happen, but we ignore that 
    private long previous_nanos = -1;
    private long nanos_when_paused = -1;
    
    private void update_simulation()
    {
    	//TODO Add list of visible players to iterate
    }

}
