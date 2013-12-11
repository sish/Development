package andreas.joelsson.oruuppgift5;

import java.util.HashMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import android.util.Log;

public class ZombiePlayerC implements IZombieBaseC {
	
	// Extended states from IZombieBase for startup.
	static final int LOGGED_OUT = 2;
	static final int LOGGING_IN = 3;
	static final int UPDATE_VISIBILITY = 4;
	static final int UPDATE_POSITION = 5;
	static final int QUERY_WHAT_I_AM = 6;
	static final int QUERY_POSITION = 7;
	static final int QUERY_PLAYERS = 8;
	static final int LOGGED_IN = 9;
	
	// Parameters
	private String Name;
	private ZombieType Type;
	private int PlayerNumber;
	private Coordinate Position;
	private int CurrentState;
	private int CommandCounter;
	private final int DefaultVisibility = 100;
	private int Visibility;
	private boolean IsLoggedIn;
	private String Version;
	private int RequestedVisiblity;
	private HashMap<Integer, COMMANDS> CommandMap = new HashMap<Integer, COMMANDS>();
	private HashMap<Integer, IMessageResponse> CallbackInterface = new HashMap<Integer, IMessageResponse>();
	private IMainActivityAccess Main = null;
	
	public enum COMMANDS {
		E_REGISTER,
		E_LOGIN,
		E_LOGOUT,
		E_POSITION,
		E_WHATAMI,
		E_WHEREAMI,
		E_VISIBILITY,
		E_PLAYERS,
		E_TURN
	}
	
	static final String S_CMD_REGISTER = "%d REGISTER %s %s"; 		// nummer REGISTER namn lösenord
	static final String S_CMD_LOGIN = "%d LOGIN %s %s";				// nummer LOGIN namn lösenord
	static final String S_CMD_LOGOUT = "%d LOGOUT";					// nummer LOGOUT
	static final String S_CMD_POSITION = "%d I-AM-AT %f %f";		// nummer I-AM-AT latitud longitud
	static final String S_CMD_WHATAMI = "%d WHAT-AM-I";				// nummer WHAT-AM-I
	static final String S_CMD_WHEREAMI = "%d WHERE-AM-I";			// nummer WHERE-AM-I
	static final String S_CMD_VISIBILITY = "%d SET-VISIBILITY %d";	// nummer SET-VISIBILITY avstånd
	static final String S_CMD_PLAYERS = "%d LIST-VISIBLE-PLAYERS";	// nummer LIST-VISIBLE-PLAYERS
	static final String S_CMD_TURN = "%d TURN %s";					// nummer TURN status
	
	static final String S_CHECK_PLAYER = "PLAYER";
	static final String S_CHECK_ASYNC_YOUARE = "YOU-ARE";
	static final String S_CHECK_ASYNC_PLAYER = "PLAYER";
	static final String S_CHECK_ASYNC_GONE = "GONE";
	
	static final String S_SERVER_REGEX = "^(\\d+)\\s([A-Z-]+)\\s?(.*)$";
	static final Pattern P_SERVER_REGEX = Pattern.compile(S_SERVER_REGEX);
	
	static final String S_LATLONG_REGEX = "^([0-9]*\\.?[0-9]*)\\s([0-9]*\\.?[0-9]*)$";
	static final Pattern P_LATLONG_REGEX = Pattern.compile(S_LATLONG_REGEX);
	
	static final String S_DUALNUMERIC_REGEX = "^([0-9]*\\.?[0-9]*)\\s([0-9]*)$";
	static final Pattern P_DUALNUMERIC_REGEX = Pattern.compile(S_DUALNUMERIC_REGEX);
	
	static final String S_VERSION_REGEX = "^[A-Za-z]+\\s([0-9]+\\.?[0-9]*)$";
	static final Pattern P_VERSION_REGEX = Pattern.compile(S_VERSION_REGEX);
	
	static final String S_ASYNC_REGEX = "^ASYNC\\s([A-Za-z-]+)\\s([A-Za-z]+)\\s?([A-Z]+)?\\s?([0-9]+\\.?[0-9]*)?\\s?([0-9]+\\.?[0-9]*)?$";
	static final Pattern P_ASYNC_REGEX = Pattern.compile(S_ASYNC_REGEX);
	
	/**
	 * Constructor
	 * @brief Defaults the type to human.
	 * @param [in] main IMainActivityAccess interface to access main methods.
	 */
	public ZombiePlayerC(IMainActivityAccess main)
	{
		Log.v("ZombiePlayerC", "ZombiePlayerC(" + main + ")");
		init(main, "", ZombieType.HUMAN);
	}
	
	/**
	 * Constructor
	 * @brief Defaults the type to human.
	 * @param [in] main IMainActivityAccess interface to access main methods.
	 * @param [in] name String with the name used for the player.
	 */
	public ZombiePlayerC(IMainActivityAccess main, String name)
	{
		Log.v("ZombiePlayerC", "ZombiePlayerC(" + main + ", " + name + ")");
		init(main, name, ZombieType.HUMAN);
	}
	
	/**
	 * Constructor
	 * @param [in] main IMainActivityAccess interface to access main methods.
	 * @param [in] name String with the name used for the player.
	 * @param [in] type ZombieType what the player starts as.
	 */
	public ZombiePlayerC(IMainActivityAccess main, String name, ZombieType type)
	{
		Log.v("ZombiePlayerC", "ZombiePlayerC(" + main + ", " + name + ", " + type + ")");
		init(main, name, type);
	}
	
	protected void init(IMainActivityAccess main, String name, ZombieType type)
	{
		Log.v("ZombiePlayerC", "init(" + main + ", " + name + ", " + type + ")");
		this.Name = name;
		this.Type = type;
		this.Main = main;
		this.CommandCounter = 0;
		this.PlayerNumber = -1;
		this.Visibility = 0;
		this.RequestedVisiblity = 0;
		this.Version = "";
		this.IsLoggedIn = false;
		this.Position = new Coordinate(59.25402118133545, 15.247076153755188);
		this.CurrentState = RUNNING;
	}
	
	public boolean IsVersionReceived()
	{
		return (this.Version != "");
	}

	@Override
	public HandleRetValue HandleInMessage(String message) throws Exception
	{
		Log.v("ZombiePlayerC", "HandleInMessage(" + message + ")");
		boolean MessageHandled;
		Matcher match = P_SERVER_REGEX.matcher(message);
		Matcher connect = P_VERSION_REGEX.matcher(message);
		Matcher async = P_ASYNC_REGEX.matcher(message);
		/*if( true != match.find() && true != connect.find() && true != async.find() ) {
			Log.e("ZombiePlayerC", "HandleInMessage: no match for regexp found!!");
			MessageHandled = false;
		} else */if( true == connect.find() ) { // Version Message
			Log.d("ZombiePlayerC", "HandleInMessage: Version Message found.");
			if( 1 != connect.groupCount() ) {
				Log.e("ZombiePlayerC", "HandleInMessage: Connect string returned more than 1 groupcount (" + connect.groupCount() + ")");
				MessageHandled = false;
			} else {
				Version = connect.group(1);
				MessageHandled = true;
			}
		} else if( true == async.find() ) { // ASYNC matches
			Log.d("ZombiePlayerC", "HandleInMessage: ASYNC Message found.");
			//TODO Duplicate Code with ZombieClientC for async messages, extract.
			//ASYNC YOU-ARE ZOMBIE
			//ASYNC YOU-ARE HUMAN
			//ASYNC PLAYER anna HUMAN 30.001 30.002
			//ASYNC PLAYER olle ZOMBIE 15 16
			//ASYNC PLAYER olle GONE
			if ( 1 > async.groupCount() ) {
				Log.e("ZombiePlayerC", "HandleInMessage: async does not match enought groups to check what kind it is. expected > 1 but was: " + async.groupCount());
				MessageHandled = false;
			} else if (S_CHECK_ASYNC_YOUARE.equals(async.group(1))) {
				//ASYNC YOU-ARE ZOMBIE
				//ASYNC YOU-ARE HUMAN
				if ( 2 > async.groupCount() ) {
					Log.e("ZombiePlayerC", "HandleInMessage: async does not match enought groups to check what type you are.");
					MessageHandled = false;
				} else if( S_HUMAN.equals(async.group(2))) {
					this.Type = ZombieType.HUMAN;
					MessageHandled = true;
				} else if( S_ZOMBIE.equals(async.group(2))) {
					this.Type = ZombieType.ZOMBIE;
					MessageHandled = true;
				} else {
					Log.e("ZombiePlayerC", "HandleInMessage: Async unknown third argument: " + async.group(2) + ".");
					MessageHandled = false;
				}
			} else if (S_CHECK_ASYNC_PLAYER.equals(async.group(1))) {
				//ASYNC PLAYER anna HUMAN 30.001 30.002
				//ASYNC PLAYER olle ZOMBIE 15 16
				//ASYNC PLAYER olle GONE
				if ( 2 > async.groupCount() ) {
					Log.e("ZombiePlayerC", "HandleInMessage: async does not match enough groups to check gone or pos. expected > 2 but was: " + async.groupCount());
					MessageHandled = false;
				} else if( false == this.Name.equals(async.group(2))) {
					// message not for us.
					Log.d("ZombiePlayerC", "HandleInMessage: async not for us.");
					MessageHandled = false;
				} else if (S_CHECK_ASYNC_GONE.equals(async.group(3))) {
					//ASYNC PLAYER olle GONE
					if( this.Name.equals(async.group(2))) {
						MessageHandled = false;
						throw new Exception("We are gone, weird to receive that ASYNC!!!");
					} else {
						MessageHandled = false;
					}
				} else if( 5 != async.groupCount() ) {
					Log.e("ZombiePlayerC", "HandleInMessage: async does not match enough groups to check pos. expected 5 but was: " + async.groupCount());
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
					Log.e("ZombiePlayerC", "HandleInMessage: Async unknown third argument: " + async.group(3) + ".");
					MessageHandled = false;
				}
			} else {
				Log.e("ZombiePlayerC", "HandleInMessage: Async unknown second argument: " + async.group(1) + ".");
				MessageHandled = false;
			}
		} else if (true == match.find() ) { // true == match.find() // numeric matches---------
			Log.d("ZombiePlayerC", "HandleInMessage: Numeric Message found.");
			int key = -1;
			try {
				key = Integer.parseInt(match.group(1));
				if( match.group(2).equals(S_CHECK_PLAYER) ) {
					Matcher newplayer = ZombieClientC.P_LISTPLAYERS_REGEX.matcher(message);
					if( true == newplayer.find() && 6 == newplayer.groupCount() && newplayer.group(2).equals("PLAYER") ) {
						// 4711 PLAYER olle HUMAN 30.1 30.1 
						if( null == Main ) {
							Log.e("ZombiePlayerC", "HandleInMessage: Cannot add player due to main is null.");
							MessageHandled = false;
						} else {
							String name = newplayer.group(3);
							if( name.equals(this.Name) ) {
								this.Type = (true == newplayer.group(4).equals(ZombieClientC.S_HUMAN) ) ? ZombieType.HUMAN : ZombieType.ZOMBIE;
								this.Position.setLatitude(Double.parseDouble(newplayer.group(5)));
								this.Position.setLongitude(Double.parseDouble(newplayer.group(6)));
								MessageHandled = true;
							} else if( Main.DoesPlayerExist(name) ) {
								MessageHandled = false;
							} else {
								ZombieType Type = (true == newplayer.group(4).equals(ZombieClientC.S_HUMAN) ) ? ZombieType.HUMAN : ZombieType.ZOMBIE;
								Double Latitude = Double.parseDouble(newplayer.group(5));
								Double Longitude = Double.parseDouble(newplayer.group(6));
								Main.RegisterProcedure(new ZombieClientC(name, Latitude, Longitude, Type));
								MessageHandled = true;
							}
						}
					} else {
						Log.e("ZombiePlayerC", "Unable to parse player!!!");
						MessageHandled = false;
					}
				} else if( true != CommandMap.containsKey(key) ) {
					Log.e("ZombiePlayerC", "HandleInMessage: Unknown id " + key + " returned from server.");
					MessageHandled = false;
				} else {
					MessageHandled = true;
					switch(CommandMap.get(key)) {
						case E_LOGIN:
						{
							if( true == CallbackInterface.containsKey(key) ) {
								CallbackInterface.get(key).MessageResponse(COMMANDS.E_LOGIN, key, message);
								CallbackInterface.remove(key);
							}
							HandleLogin(match.group(2), match.group(3));
							CommandMap.remove(key);
							break;
						}
						case E_LOGOUT:
						{
							HandleLogout(match.group(2), match.group(3));
							CommandMap.remove(key);
							break;
						}
						case E_PLAYERS:
						{
							HandlePlayers(match.group(2), match.group(3));
							CommandMap.remove(key);
							break;
						}
						case E_POSITION:
						{
							HandlePosition(match.group(2), match.group(3));
							CommandMap.remove(key);
							break;
						}
						case E_REGISTER:
						{
							if( true == CallbackInterface.containsKey(key) ) {
								CallbackInterface.get(key).MessageResponse(COMMANDS.E_REGISTER, key, message);
								CallbackInterface.remove(key);
							}
							HandleRegister(match.group(2), match.group(3));
							CommandMap.remove(key);
							break;
						}
						case E_TURN:
						{
							HandleTurn(match.group(2), match.group(3));
							CommandMap.remove(key);
							break;
						}
						case E_VISIBILITY:
						{
							HandleVisibility(match.group(2), match.group(3));
							CommandMap.remove(key);
							break;
						}
						case E_WHATAMI:
						{
							HandleWhatAmI(match.group(2), match.group(3));
							CommandMap.remove(key);
							break;
						}
						case E_WHEREAMI:
						{
							HandleWhereAmI(match.group(2), match.group(3));
							CommandMap.remove(key);
							break;
						}
						default:
						{
							Log.e("ZombiePlayerC", "HandleInMessage: default switch statement " + CommandMap.get(key) + " in commandmap.");
							MessageHandled = false;
							break;
						}
					}
				}
			} catch (Exception e) {
				Log.e("ZombiePlayerC", "HandleInMessage: Exception thrown = " + e.getMessage());
				MessageHandled = false;
				CommandMap.remove(key);
				this.CurrentState = RUNNING; // disrupt login sequence if any.
			}
		} else {
			Log.e("ZombiePlayerC", "HandleInMessage: no match for regexp found!!");
			MessageHandled = false;
		}
		return new HandleRetValue(CurrentState, MessageHandled);
	}
	
	/**
	 * @param command
	 * @param arguments
	 * @throws Exception
	 * <H2>Message sent</H2>
	 * @code
	 * nummer LOGIN namn lösenord
	 * @endcode
	 * <H2>Return values</H2>
	 * @code
	 * nummer WELCOME spelarnummer 
	 * nummer ERROR BAD-ARGUMENTS 
	 * nummer ERROR UNKNOWN-PLAYER 
	 * nummer ERROR WRONG-PASSWORD 
	 * nummer ERROR THIS-CLIENT-ALREADY-LOGGED-IN 
	 * nummer ERROR THAT-PLAYER-ALREADY-LOGGED-IN
	 * @endcode
	 */
	protected void HandleLogin(String command, String arguments) throws Exception
	{
		Log.v("ZombiePlayerC", "HandleLogin(" + command + ", " + arguments + ")");
		if( command.equals("WELCOME") ) {
			if( LOGGING_IN != CurrentState ) {
				throw new Exception("Login response received when not trying to log in.");
			}
			this.PlayerNumber = Integer.parseInt(arguments);
			this.IsLoggedIn = true;
			UpdateVisibility(DefaultVisibility);
			this.CurrentState = UPDATE_VISIBILITY;
		} else if( command.equals("ERROR") ) {
			throw new Exception("Login received error " + arguments + ".");
		} else {
			throw new Exception("Unknown command " + command + " received in login response.");
		}
	}
	
	/**
	 * 
	 * @param command
	 * @param arguments
	 * @throws Exception
	 * <H2>Message sent</H2>
	 * @code
	 * nummer LOGOUT
	 * @endcode
	 * <H2>Return values</H2>
	 * @code
	 * nummer GOODBYE 
	 * nummer ERROR BAD-ARGUMENTS 
	 * nummer ERROR NOT-LOGGED-IN
	 * @endcode
	 */
	protected void HandleLogout(String command, String arguments) throws Exception
	{
		Log.v("ZombiePlayerC", "HandleLogout(" + command + ", " + arguments + ")");
		if( command.equals("GOODBYE") ) {
			// do nothing, we are done. notify that we are logged out perhaps.
			this.IsLoggedIn = false;
			Main.SetMenuEnabled();
			this.CurrentState = LOGGED_OUT;
		} else if( command.equals("ERROR") ) {
			throw new Exception("Logout received error " + arguments + ".");
		} else {
			throw new Exception("Unknown command " + command + " received in logout response.");
		}
	}
	
	/**
	 * 
	 * @param command
	 * @param arguments
	 * @throws Exception
	 * <H2>Message sent</H2>
	 * @code
	 * nummer LIST-VISIBLE-PLAYERS
	 * @endcode
	 * <H2>Return values</H2>
	 * @code
	 * nummer VISIBLE-PLAYERS avstånd antal 
	 * (följt av spelarnas positioner, en per rad) 
	 * nummer ERROR BAD-ARGUMENTS 
	 * nummer ERROR UNKNOWN-POSITION 
	 * nummer ERROR NOT-LOGGED-IN
	 * @endcode
	 */
	protected void HandlePlayers(String command, String arguments) throws Exception
	{
		Log.v("ZombiePlayerC", "HandlePlayers(" + command + ", " + arguments + ")");
		if( command.equals("VISIBLE-PLAYERS") ) {
			Matcher match = P_DUALNUMERIC_REGEX.matcher(arguments);
			if( true != match.find() ) {
				throw new Exception("HandlePlayers regexp match error on " + arguments + ".");
			} else if ( 2 != match.groupCount() ) {
				throw new Exception("HandlePlayers regexp didn't match 2 groups but " + match.groupCount() + ".");
			} else {
				if( QUERY_PLAYERS == this.CurrentState ) { // Login Sequence
					this.CurrentState = LOGGED_IN;
				}
			}
		} else if( command.equals("ERROR") ) {
			throw new Exception("Visible Players received error " + arguments + ".");
		} else {
			throw new Exception("Unknown command " + command + " received in Visible Players response.");
		}
	}
	
	/**
	 * 
	 * @param command
	 * @param arguments
	 * @throws Exception
	 * <H2>Message sent</H2>
	 * @code
	 * nummer I-AM-AT latitud longitud
	 * @endcode
	 * <H2>Return values</H2>
	 * @code
	 * nummer OK 
	 * nummer ERROR BAD-ARGUMENTS 
	 * nummer ERROR NOT-LOGGED-IN
	 * @endcode
	 */
	protected void HandlePosition(String command, String arguments) throws Exception
	{
		Log.v("ZombiePlayerC", "HandlePosition(" + command + ", " + arguments + ")");
		if( command.equals("OK") ) {
			if( UPDATE_POSITION == this.CurrentState ) { // startup sequence
				AskWhatIAm();
				this.CurrentState = QUERY_WHAT_I_AM;
			}
		} else if( command.equals("ERROR") ) {
			throw new Exception("Position received error " + arguments + ".");
		} else {
			throw new Exception("Unknown command " + command + " received in Position response.");
		}
	}
	
	/**
	 * 
	 * @param command
	 * @param arguments
	 * @throws Exception
	 * <H2>Message sent</H2>
	 * @code
	 * nummer REGISTER namn lösenord
	 * @endcode
	 * <H2>Return values</H2>
	 * @code
	 * nummer REGISTERED spelarnummer 
	 * nummer ERROR BAD-ARGUMENTS 
	 * nummer ERROR NAME-ALREADY-REGISTERED
	 * @endcode
	 */
	protected void HandleRegister(String command, String arguments) throws Exception
	{
		Log.v("ZombiePlayerC", "HandleRegister(" + command + ", " + arguments + ")");
		if( command.equals("REGISTERED") ) {
			PlayerNumber = Integer.parseInt(arguments);
		} else if( command.equals("ERROR") ) {
			throw new Exception("Register received error " + arguments + ".");
		} else {
			throw new Exception("Unknown command " + command + " received in Register response.");
		}
	}
	
	/**
	 * 
	 * @param command
	 * @param arguments
	 * @throws Exception
	 * <H2>Message sent</H2>
	 * @code
	 * nummer TURN status
	 * @endcode
	 * <H2>Return values</H2>
	 * @code
	 * nummer OK 
	 * nummer ERROR BAD-ARGUMENTS 
	 * nummer ERROR CANNOT-TURN 
	 * nummer ERROR NOT-LOGGED-IN
	 * @endcode
	 */
	protected void HandleTurn(String command, String arguments) throws Exception
	{
		Log.v("ZombiePlayerC", "HandleTurn(" + command + ", " + arguments + ")");
		if( command.equals("OK") ) {
			Type = (ZombieType.HUMAN != Type) ? ZombieType.HUMAN : ZombieType.ZOMBIE;
		} else if( command.equals("ERROR") ) {
			throw new Exception("Turn received error " + arguments + ".");
		} else {
			throw new Exception("Unknown command " + command + " received in Turn response.");
		}
	}
	
	/**
	 * 
	 * @param command
	 * @param arguments
	 * @throws Exception
	 * <H2>Message sent</H2>
	 * @code
	 * nummer SET-VISIBILITY avstånd
	 * @endcode
	 * <H2>Return values</H2>
	 * @code
	 * nummer OK 
	 * nummer ERROR BAD-ARGUMENTS 
	 * nummer ERROR NOT-LOGGED-IN
	 * @endcode
	 */
	protected void HandleVisibility(String command, String arguments) throws Exception
	{
		Log.v("ZombiePlayerC", "HandleVisibility(" + command + ", " + arguments + ")");
		if( command.equals("OK") ) {
			this.Visibility = this.RequestedVisiblity;
			if( UPDATE_VISIBILITY == this.CurrentState ) { // startup
				UpdatePosition(Position);
				this.CurrentState = UPDATE_POSITION;
			}
		} else if( command.equals("ERROR") ) {
			throw new Exception("Visibility received error " + arguments + " when requesting " + this.RequestedVisiblity + " visibility.");
		} else {
			throw new Exception("Unknown command " + command + " received in Visibility response.");
		}
	}
	
	/**
	 * 
	 * @param command
	 * @param arguments
	 * @throws Exception
	 * <H2>Message sent</H2>
	 * @code
	 * nummer WHAT-AM-I
	 * @endcode
	 * <H2>Return values</H2>
	 * @code
	 * nummer YOU-ARE HUMAN 
	 * nummer YOU-ARE ZOMBIE 
	 * nummer ERROR BAD-ARGUMENTS 
	 * nummer ERROR NOT-LOGGED-IN
	 * @endcode
	 */
	protected void HandleWhatAmI(String command, String arguments) throws Exception
	{
		Log.v("ZombiePlayerC", "HandleWhatAmI(" + command + ", " + arguments + ")");
		if( command.equals("YOU-ARE") ) {
			Type = (arguments.equals("HUMAN")) ? ZombieType.HUMAN : ZombieType.ZOMBIE;
			if( QUERY_WHAT_I_AM == this.CurrentState ) { // Login Sequence
				AskWhereIAm();
				this.CurrentState = QUERY_POSITION;
			}
		} else if( command.equals("ERROR") ) {
			throw new Exception("WhatAmI received error " + arguments + ".");
		} else {
			throw new Exception("Unknown command " + command + " received in WhatAmI response.");
		}
	}
	
	/**
	 * 
	 * @param command
	 * @param arguments
	 * @throws Exception
	 * <H2>Message sent</H2>
	 * @code
	 * nummer WHERE-AM-I
	 * @endcode
	 * <H2>Return values</H2>
	 * @code
	 * nummer YOU-ARE-AT latitud longitud 
	 * nummer ERROR BAD-ARGUMENTS 
	 * nummer ERROR UNKNOWN-POSITION 
	 * nummer ERROR NOT-LOGGED-IN
	 * @endcode
	 */
	protected void HandleWhereAmI(String command, String arguments) throws Exception
	{
		Log.v("ZombiePlayerC", "WhereAmI(" + command + ", " + arguments + ")");
		if( command.equals("YOU-ARE-AT") ) {
			Matcher match = P_LATLONG_REGEX.matcher(arguments);
			if( true != match.find() ) {
				throw new Exception("WhereAmI regexp match error on " + arguments + ".");
			} else if ( 2 != match.groupCount() ) {
				throw new Exception("WhereAmI regexp didn't match 2 groups but " + match.groupCount() + ".");
			} else {
				this.Position.setLatitude(Double.parseDouble(match.group(1)));
				this.Position.setLongitude(Double.parseDouble(match.group(2)));
				if( QUERY_POSITION == this.CurrentState ) { // Login Sequence
					UpdatePlayers();
					this.CurrentState = QUERY_PLAYERS;
				}
			}
		} else if( command.equals("ERROR") ) {
			throw new Exception("WhereAmI received error " + arguments + ".");
		} else {
			throw new Exception("Unknown command " + command + " received in WhereAmI response.");
		}
	}
	
	public boolean SendRegister(String password)
	{
		Log.v("ZombiePlayerC", "SendRegister(" + password + ")");
		return SendRegister(this.Name, password);
	}
	
	public boolean SendRegister(String name, String password, IMessageResponse callback)
	{
		Log.v("ZombiePlayerC", "SendRegister(" + name + ", " + password + ", " + callback + ")");
		boolean retValue = SendRegister(name, password);
		CallbackInterface.put(CommandCounter, callback);
		return retValue;
	}
	
	public boolean SendRegister(String name, String password)
	{
		Log.v("ZombiePlayerC", "SendRegister(" + name + ", " + password + ")");
		boolean retValue = true;
		if( true != Main.IsConnected() ) {
			Log.e("ZombiePlayerC", "Not connected to server.");
			retValue = false;
		}
		else if( CommandMap.containsValue(COMMANDS.E_REGISTER) ) {
			Log.e("ZombiePlayerC", "Waiting for response for previous register command.");
			retValue = false;
		} else if( null == Main ) {
			Log.e("ZombiePlayerC", "Main activity not accecible by interface, did you instance this correct?.");
			retValue = false;
		} else {
			CommandCounter++;
			Main.SendMessage(String.format(S_CMD_REGISTER, CommandCounter, name, password));
			CommandMap.put(CommandCounter, COMMANDS.E_REGISTER);
		}
		return retValue;
	}
	
	public boolean SendLogin(String password)
	{
		Log.v("ZombiePlayerC", "SendLogin(" + password + ")");
		return SendLogin(this.Name, password);
	}
	
	public boolean SendLogin(String name, String password, IMessageResponse callback)
	{
		Log.v("ZombiePlayerC", "SendLogin(" + name + ", " + password + ", " + callback + ")");
		boolean retValue = SendLogin(name, password);
		CallbackInterface.put(CommandCounter, callback);
		return retValue;
	}
	
	public boolean SendLogin(String name, String password)
	{
		Log.v("ZombiePlayerC", "SendLogin(" + name + ", " + password + ")");
		boolean retValue = true;
		if( null == Main ) {
			Log.e("ZombiePlayerC", "Main activity not accecible by interface, did you instance this correct?.");
			retValue = false;
		} else if( true != Main.IsConnected() ) {
			Log.e("ZombiePlayerC", "Not connected to server.");
			retValue = false;
		} else if( CommandMap.containsValue(COMMANDS.E_LOGIN) ) {
			Log.e("ZombiePlayerC", "Waiting for response for previous login command.");
			retValue = false;
		} else if(RUNNING != this.CurrentState && LOGGED_OUT != this.CurrentState) {
			Log.e("ZombiePlayerC", "Invalid state " + this.CurrentState + " whe calling login.");
			retValue = false;
		} else {
			CommandCounter++;
			if( this.Name.equals("") ) {
				this.Name = name;
			}
			Main.SendMessage(String.format(S_CMD_LOGIN, CommandCounter, name, password));
			CommandMap.put(CommandCounter, COMMANDS.E_LOGIN);
			this.CurrentState = LOGGING_IN;
		}
		return retValue;
	}
	
	public boolean SendLogout()
	{
		Log.v("ZombiePlayerC", "SendLogout()");
		boolean retValue = true;
		if( true != Main.IsConnected() ) {
			Log.e("ZombiePlayerC", "Not connected to server.");
			retValue = false;
		} else if( CommandMap.containsValue(COMMANDS.E_LOGOUT) ) {
			Log.e("ZombiePlayerC", "Waiting for response for previous logout command.");
			retValue = false;
		} else if( null == Main ) {
			Log.e("ZombiePlayerC", "Main activity not accecible by interface, did you instance this correct?.");
			retValue = false;
		} else {
			CommandCounter++;
			Main.SendMessage(String.format(S_CMD_LOGOUT, CommandCounter));
			CommandMap.put(CommandCounter, COMMANDS.E_LOGOUT);
		}
		return retValue;
	}
	
	public boolean UpdatePosition(Coordinate position)
	{
		Log.v("ZombiePlayerC", "UpdatePosition(" + position.getLatitude() + ", " + position.getLongitude() + ")");
		boolean retValue = true;
		if( true != Main.IsConnected() ) {
			Log.e("ZombiePlayerC", "Not connected to server.");
			retValue = false;
		} else if( CommandMap.containsValue(COMMANDS.E_POSITION) ) {
			Log.e("ZombiePlayerC", "Waiting for response for previous position update command.");
			retValue = false;
		} else if( null == Main ) {
			Log.e("ZombiePlayerC", "Main activity not accecible by interface, did you instance this correct?.");
			retValue = false;
		} else {
			CommandCounter++;
			this.Position.updatePosition(position);
			Main.SendMessage(String.format(S_CMD_POSITION, CommandCounter, this.Position.getLatitude(), this.Position.getLongitude()));
			CommandMap.put(CommandCounter, COMMANDS.E_POSITION);
		}
		return retValue;
	}
	
	public boolean AskWhatIAm()
	{
		Log.v("ZombiePlayerC", "AskWhatIAm()");
		boolean retValue = true;
		if( true != Main.IsConnected() ) {
			Log.e("ZombiePlayerC", "Not connected to server.");
			retValue = false;
		} else if( CommandMap.containsValue(COMMANDS.E_WHATAMI) ) {
			Log.e("ZombiePlayerC", "Waiting for response for previous what am I command.");
			retValue = false;
		} else if( null == Main ) {
			Log.e("ZombiePlayerC", "Main activity not accecible by interface, did you instance this correct?.");
			retValue = false;
		} else {
			CommandCounter++;
			Main.SendMessage(String.format(S_CMD_WHATAMI, CommandCounter));
			CommandMap.put(CommandCounter, COMMANDS.E_WHATAMI);
		}
		return retValue;
	}
	
	public boolean AskWhereIAm()
	{
		Log.v("ZombiePlayerC", "AskWhereIAm()");
		boolean retValue = true;
		if( true != Main.IsConnected() ) {
			Log.e("ZombiePlayerC", "Not connected to server.");
			retValue = false;
		} else if( CommandMap.containsValue(COMMANDS.E_WHEREAMI) ) {
			Log.e("ZombiePlayerC", "Waiting for response for previous where I am command.");
			retValue = false;
		} else if( null == Main ) {
			Log.e("ZombiePlayerC", "Main activity not accecible by interface, did you instance this correct?.");
			retValue = false;
		} else {
			CommandCounter++;
			Main.SendMessage(String.format(S_CMD_WHEREAMI, CommandCounter));
			CommandMap.put(CommandCounter, COMMANDS.E_WHEREAMI);
		}
		return retValue;
	}
	
	public boolean UpdateVisibility(int length)
	{
		Log.v("ZombiePlayerC", "UpdateVisibility(" + length + ")");
		boolean retValue = true;
		if( true != Main.IsConnected() ) {
			Log.e("ZombiePlayerC", "Not connected to server.");
			retValue = false;
		} else if( CommandMap.containsValue(COMMANDS.E_VISIBILITY) ) {
			Log.e("ZombiePlayerC", "Waiting for response for previous visibility command.");
			retValue = false;
		} else if( null == Main ) {
			Log.e("ZombiePlayerC", "Main activity not accecible by interface, did you instance this correct?.");
			retValue = false;
		} else {
			CommandCounter++;
			Main.SendMessage(String.format(S_CMD_VISIBILITY, CommandCounter, length));
			CommandMap.put(CommandCounter, COMMANDS.E_VISIBILITY);
			this.RequestedVisiblity = length;
		}
		return retValue;
	}
	
	public boolean UpdatePlayers()
	{
		Log.v("ZombiePlayerC", "UpdatePlayers()");
		boolean retValue = true;
		if( true != Main.IsConnected() ) {
			Log.e("ZombiePlayerC", "Not connected to server.");
			retValue = false;
		} else if( CommandMap.containsValue(COMMANDS.E_PLAYERS) ) {
			Log.e("ZombiePlayerC", "Waiting for response for previous players command.");
			retValue = false;
		} else if( null == Main ) {
			Log.e("ZombiePlayerC", "Main activity not accecible by interface, did you instance this correct?.");
			retValue = false;
		} else {
			CommandCounter++;
			Main.SendMessage(String.format(S_CMD_PLAYERS, CommandCounter));
			CommandMap.put(CommandCounter, COMMANDS.E_PLAYERS);
		}
		return retValue;
	}
	
	public boolean DebugTurnMe(ZombieType to)
	{
		Log.v("ZombiePlayerC", "DebugTurnMe(" + to + ")");
		boolean retValue = true;
		if( true != Main.IsConnected() ) {
			Log.e("ZombiePlayerC", "Not connected to server.");
			retValue = false;
		} else if( CommandMap.containsValue(COMMANDS.E_TURN) ) {
			Log.e("ZombiePlayerC", "Waiting for response for previous turn command.");
			retValue = false;
		} else if( null == Main ) {
			Log.e("ZombiePlayerC", "Main activity not accecible by interface, did you instance this correct?.");
			retValue = false;
		} else {
			CommandCounter++;
			Main.SendMessage(String.format(S_CMD_TURN, CommandCounter, (ZombieType.HUMAN == to) ? S_HUMAN : S_ZOMBIE));
			CommandMap.put(CommandCounter, COMMANDS.E_TURN);
		}
		return retValue;
	}
	
	@Override
	public boolean IsHuman()
	{
		return (ZombieType.HUMAN == Type);
	}
	
	@Override
	public boolean IsZombie()
	{
		return (ZombieType.ZOMBIE == Type);
	}
	
	public boolean IsLoggedIn()
	{
		return IsLoggedIn;
	}
	
	public int GetVisibility()
	{
		return Visibility;
	}

	@Override
	public boolean IsPlayer() {
		return true;
	}

	@Override
	public boolean IsWithinRange(Coordinate to, int range) {
		if( Static.ShowDebug == 0 ) {
			Log.v("ZombiePlayerC", "IsWithinRange(" + to + ", " + range + ")");
		}
		float distance = this.Position.getDistance(to, Coordinate.UNIT_METERS);
		if( Static.ShowDebug == 0 ) {
			Log.d("ZombiePlayerC", range + ">" + distance + " = " + (range > distance));
		}
		return range > distance;
	}

	@Override
	public String GetName() {
		return this.Name;
	}

	@Override
	public Coordinate GetPosition() {
		return this.Position;
	}

}
