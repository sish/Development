package andreas.joelsson.oruuppgift5;

public interface IZombieBaseC {
	
	static final int ABORTED = 0;
	static final int RUNNING = 1;
	static final int COMPLETED = 9999;
	
	static final String S_HUMAN = "HUMAN";
	static final String S_ZOMBIE = "ZOMBIE";
	
	public class HandleRetValue {
		public int CurrentStatus;
		public boolean MessageHandled;
		public HandleRetValue(int status, boolean handled) {
			this.CurrentStatus = status;
			this.MessageHandled = handled;
		}
	}
	
	public static enum ZombieType {
		ZOMBIE, 
		HUMAN
	}
	
	public HandleRetValue HandleInMessage(String message) throws Exception;
	public boolean IsPlayer();
	public boolean IsWithinRange(Coordinate to, int range);
	public Coordinate GetPosition();
	public String GetName();
	public boolean IsHuman();
	public boolean IsZombie();

}
