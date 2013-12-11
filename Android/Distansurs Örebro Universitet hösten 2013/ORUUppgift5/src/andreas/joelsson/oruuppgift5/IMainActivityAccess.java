package andreas.joelsson.oruuppgift5;

public interface IMainActivityAccess {
	
	public void SendMessage(String message);
	public boolean RegisterProcedure(IZombieBaseC proc);
	public boolean IsConnected();
	public void SetMenuEnabled();
	public boolean DoesPlayerExist(String username);
	
}
