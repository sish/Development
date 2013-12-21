package andreas.joelsson.oruuppgift5;

import android.util.Log;

public class Coordinate {
	/*
	 * Latitude in wgs84 degrees
	 */
	private float Latitude;
	/*
	 * Longitude in wgs84 degrees
	 */
	private float Longitude;
	
	public static final int UNIT_MILES = 1;
	public static final int UNIT_KILOMETERS = 2;
	public static final int UNIT_NAUTICAL_MILES = 3;
	public static final int UNIT_METERS = 3;
	
	public Coordinate(float latitude, float longitude) {
		this.Latitude = latitude;
		this.Longitude = longitude;
	}
	
	public Coordinate(double latitude, double longitude) {
		this.Latitude = (float)latitude;
		this.Longitude = (float)longitude;
	}
	
	public void setLatitude(float latitude) {
		this.Latitude = latitude;
	}
	
	public void setLatitude(double latitude) {
		this.Latitude = (float)latitude;
	}
	
	public float getLatitude() {
		return this.Latitude;
	}
	
	public void setLongitude(float longitude) {
		this.Longitude = longitude;
	}
	
	public void setLongitude(double longitude) {
		this.Longitude = (float)longitude;
	}
	
	public float getLongitude() {
		return this.Longitude;
	}
	
	public void updatePosition(Coordinate update) {
		Log.v("Coordinate", "updatePosition(" + update + ")");
		setLatitude(update.getLatitude());
		setLongitude(update.getLongitude());
	}
	
	public float getDistance(Coordinate to) {
		return getDistance(to, UNIT_MILES);
	}
	
	public float getDistance(Coordinate to, int unit) {
		if( 0 == Static.ShowDebug ) {
			Log.v("Coordinate", "getDistance(" + to + ", " + unit + ")");
		}
		double lat1 = getLatitude();
		double lon1 = getLongitude();
		double lat2 = to.getLatitude();
		double lon2 = to.getLongitude();
	    double earthRadius = 3958.75;
	    double dLat = deg2rad(lat2-lat1);
	    double dLng = deg2rad(lon2-lon1);
	    double a = Math.sin(dLat/2) * Math.sin(dLat/2) +
	           Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) *
	           Math.sin(dLng/2) * Math.sin(dLng/2);
	    double c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a));
	    float dist = (float)(earthRadius * c * 1000.0f);
		/*double theta = lon1 - lon2;
		double dist = Math.sin(deg2rad(lat1)) * Math.sin(deg2rad(lat2)) + 
				Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) * Math.cos(deg2rad(theta));
		dist = Math.acos(dist);
		dist = rad2deg(dist);
		dist = dist * 60 * 1.1515;
		if (unit == UNIT_KILOMETERS) {
			dist = dist * 1.609344;
		} else if (unit == UNIT_NAUTICAL_MILES) {
			dist = dist * 0.8684;
		} else if( unit == UNIT_METERS ) {
			dist = dist * 1.609344 * 1000; 
		}*/
		if( 0 == Static.ShowDebug ) {
			Log.d("Coordinate", "getDistance: " + dist);
		}
		return (float)(dist);
	}
	
	public float getAngle(Coordinate target) {
		if( 0 == Static.ShowDebug ) {
			Log.v("Coordinate", "getAngle(" + target + ")");
		}
		float angle = (float)(Math.atan2((double)(deg2rad(target.getLatitude()) - deg2rad(getLatitude())), (double)(deg2rad(target.getLongitude()) - deg2rad(getLongitude()))));
	    if(angle < 0){
	        angle += 2 * Math.PI;
	    }
	    if( 0 == Static.ShowDebug ) {
	    	Log.d("Coordinate", "getAngle: " + angle);
	    }
	    return angle;
	}
	
	public float getLatitudeDeltaInMeters(Coordinate target)
	{
		if( 0 == Static.ShowDebug ) {
			Log.v("Coordinate", "getLatitudeDeltaInMeters(" + target + ")");
		}
		float distance = getDistance(target, UNIT_METERS);
		float angle = getAngle(target);
		float retValue = (float) (distance * Math.sin(angle));
		if( 0 == Static.ShowDebug ) {
			Log.d("Coordinate", "getLatitudeDeltaInMeters: " + retValue);
		}
		return retValue;
	}
	
	public float getLongitudeDeltaInMeters(Coordinate target)
	{
		if( 0 == Static.ShowDebug ) {
			Log.v("Coordinate", "getLongitudeDeltaInMeters(" + target + ")");
		}
		float distance = getDistance(target, UNIT_METERS);
		float angle = getAngle(target);
		float retValue = (float)(distance * Math.cos(angle));
		if( 0 == Static.ShowDebug ) {
			Log.d("Coordinate", "getLongitudeDeltaInMeters: " + retValue);
		}
		return retValue;
	}
	
	@Override
	public String toString() {
		return "Lat: " + this.Latitude + " / Long: " + this.Longitude;
	}
	
	private float deg2rad(float degrees) {
		return (float)(degrees * Math.PI / 180.0);
	}
	
	private double deg2rad(double degrees) {
		return (degrees * Math.PI / 180.0);
	}
	
	private float rad2deg(float radians) {
		return (float)(radians * 180.0 / Math.PI);
	}
	
	private double rad2deg(double radians) {
		return (radians * 180.0 / Math.PI);
	}
	
}
