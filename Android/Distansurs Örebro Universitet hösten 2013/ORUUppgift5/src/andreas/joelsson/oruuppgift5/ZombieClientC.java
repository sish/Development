package andreas.joelsson.oruuppgift5;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

import andreas.joelsson.oruuppgift5.IZombieBaseC.ZombieType;
import android.util.Log;

public class ZombieClientC implements IZombieBaseC {
	
	private String Name;
	private Coordinate Position;
	private ZombieType Type;
	private int CurrentState;
	private final String S_ASYNC_CHECK = "ASYNC PLAYER";
	private final String S_LEAVE_CHECK = "GONE";
	
	static final String S_LISTPLAYERS_REGEX = "^(\\d+)\\s([A-Z]+)\\s([A-Za-z]+)\\s([A-Z]+)\\s([0-9]*\\.?[0-9]*)\\s([0-9]*\\.?[0-9]*).*$";
	static final Pattern P_LISTPLAYERS_REGEX = Pattern.compile(S_LISTPLAYERS_REGEX);
	
	@SuppressWarnings("unused")
	private ZombieClientC() {}
	
	/**
	 * Constructor
	 * @param [in] name String with name of client.
	 * @param [in] latitude Double with the latitude of the player.
	 * @param [in] longitude Double with the longitude of the player.
	 * @param [in] type ZombieType with the enum type of player.
	 */
	public ZombieClientC(String name, Double latitude, Double longitude, ZombieType type) {
		Log.v("ZombieClientC", "ZombieClientC(" + name + ", " + latitude + ", " + longitude + ", " + type + ")");
		this.Name = name;
		this.Position = new Coordinate(latitude, longitude);
		this.Type = type;
		this.CurrentState = RUNNING;
	}

	@Override
	public HandleRetValue HandleInMessage(String message) throws Exception
	{
		Log.v("ZombieClientC", "HandleInMessage(" + message + ")");
		boolean MessageHandled = false;
		Matcher async = ZombiePlayerC.P_ASYNC_REGEX.matcher(message);
		Matcher match = P_LISTPLAYERS_REGEX.matcher(message);
		if( true == async.find() && 2 <= async.groupCount() && this.Name.equals(async.group(2)) ) { // ASYNC matches
			//TODO Duplicate Code with ZombiePlayerC for async messages, extract.
			//ASYNC YOU-ARE ZOMBIE
			//ASYNC YOU-ARE HUMAN
			//ASYNC PLAYER anna HUMAN 30.001 30.002
			//ASYNC PLAYER olle ZOMBIE 15 16
			//ASYNC PLAYER olle GONE
			if ( 1 > async.groupCount() ) {
				Log.e("ZombieClientC", "HandleInMessage: async does not match enought groups to check what kind it is.");
				MessageHandled = false;
			} else if (ZombiePlayerC.S_CHECK_ASYNC_YOUARE.equals(async.group(1))) {
				//ASYNC YOU-ARE ZOMBIE
				//ASYNC YOU-ARE HUMAN
				if ( 2 > async.groupCount() ) {
					Log.e("ZombieClientC", "HandleInMessage: async does not match enought groups to check what type you are.");
					MessageHandled = false;
				} else if( S_HUMAN.equals(async.group(2))) {
					this.Type = ZombieType.HUMAN;
					MessageHandled = true;
				} else if( S_ZOMBIE.equals(async.group(2))) {
					this.Type = ZombieType.ZOMBIE;
					MessageHandled = true;
				} else {
					Log.e("ZombieClientC", "HandleInMessage: Async unknown third argument: " + async.group(2) + ".");
					MessageHandled = false;
				}
			} else if (ZombiePlayerC.S_CHECK_ASYNC_PLAYER.equals(async.group(1))) {
				//ASYNC PLAYER anna HUMAN 30.001 30.002
				//ASYNC PLAYER olle ZOMBIE 15 16
				//ASYNC PLAYER olle GONE
				if ( 3 > async.groupCount() ) {
					Log.e("ZombieClientC", "HandleInMessage: async does not match enough groups to check gone or pos.");
					MessageHandled = false;
				} else if( false == this.Name.equals(async.group(2))) {
					// message not for us.
					MessageHandled = false;
				} else if (ZombiePlayerC.S_CHECK_ASYNC_GONE.equals(async.group(3))) {
					//ASYNC PLAYER olle GONE
					if( this.Name.equals(async.group(2))) {
						CurrentState = COMPLETED;
						MessageHandled = true;
					} else {
						MessageHandled = false;
					}
				} else if( 5 != async.groupCount() ) {
					Log.e("ZombieClientC", "HandleInMessage: async does not match enough groups to check pos.");
					MessageHandled = false;
				} else if( S_HUMAN.equals(async.group(3))) {
					this.Type = ZombieType.HUMAN;
					this.Position.setLatitude(Double.parseDouble(async.group(4)));
					this.Position.setLongitude(Double.parseDouble(async.group(5)));
					MessageHandled = true;
				} else if( S_ZOMBIE.equals(async.group(3))) {
					this.Type = ZombieType.ZOMBIE;
					this.Position.setLatitude(Double.parseDouble(async.group(4)));
					this.Position.setLongitude(Double.parseDouble(async.group(5)));
					MessageHandled = true;
				} else {
					Log.e("ZombieClientC", "HandleInMessage: Async unknown third argument: " + async.group(3) + ".");
					MessageHandled = false;
				}
			} else {
				Log.e("ZombieClientC", "HandleInMessage: Async unknown second argument: " + async.group(1) + ".");
				MessageHandled = false;
			}
		} else if( match.find() && match.group(3).equals(this.Name)) {
			// Response after a LIST-PLAYERS command
			// 4711 PLAYER olle HUMAN 30.1 30.1
			if( 6 != match.groupCount() ) {
				throw new Exception("HandleInMessage for ZombieClient did not match 6 groups but " + match.groupCount() + ".");
			} else {
				//TODO not a solid solution.
				this.Type = (true == match.group(4).equals(S_HUMAN) ) ? ZombieType.HUMAN : ZombieType.ZOMBIE;
				this.Position.setLatitude(Double.parseDouble(match.group(5)));
				this.Position.setLongitude(Double.parseDouble(match.group(6)));
				MessageHandled = true;
			}
		} else {
			Log.d("ZombieClientC", "No match in method HandleInMessage for player: " + this.Name);
			MessageHandled = false;
		} 
		return new HandleRetValue(CurrentState, MessageHandled);
	}

	@Override
	public boolean IsPlayer() {
		return false;
	}

	@Override
	public String GetName() {
		return this.Name;
	}

	@Override
	public boolean IsWithinRange(Coordinate to, int range) {
		return range > this.Position.getDistance(to, Coordinate.UNIT_METERS);
	}

	@Override
	public Coordinate GetPosition() {
		return this.Position;
	}

	@Override
	public boolean IsHuman() {
		return (ZombieType.HUMAN == Type);
	}

	@Override
	public boolean IsZombie() {
		return (ZombieType.ZOMBIE == Type);
	}

}
