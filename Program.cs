/*
 * Created by SharpDevelop.
 * User: havyck
 * Date: 6/22/2010
 * Time: 12:30 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace DelegateResearch
{
	class Nebula
	{
		private string classLeader;
    	private string classification;
    	private int contractNumber;
    	private int crewCompliment;
    	private int lifeExpectancy;
    	
    	 public Nebula(string leader, string classif, int number, int compliment, int lifespan)
    	 {
    	 	this.classLeader = leader;
      		this.classification = classif;
      		this.crewCompliment = compliment;
      		this.contractNumber = number;
      		this.lifeExpectancy = lifespan;
    	 }

    	  public string Leader
    	  {
      		get {return classLeader;}
      		set {classLeader = value;}
          }
		 
    	  public string classif
    	  {
      		get {return classification;}
      		set {classification = value;}
          }
    	 
    	  public int crew
    	  {
      		get {return crewCompliment;}
      		set {crewCompliment = value;}
          }
    	      
    	  public int number
    	  {
      		get {return contractNumber;}
      		set {contractNumber = value;}
          }
    	  
    	  public int expectancy
    	  {
      		get {return lifeExpectancy;}
      		set {lifeExpectancy = value;}
          }
    	  
    	  public override string ToString()
    	  {	
      		return String.Format("{0} is online with a life expectancy of {1} years", classification, lifeExpectancy);
    	  }
	}
	
	class Fleet
	{
		private Nebula[] ships;
    	private string designation;
    	public Fleet(Nebula[] theShips, string desig)
    	{
      		ships = theShips;
      		this.designation = desig;
    	}
    	
   	 	public string Name
    	{
      		get
      		{
        		return designation;
      		}
   	 	}
      	
      	// Declaring a nested delegate type that accepts an Nebula instance
    	public delegate void NebulaCallback(Nebula nx);
    	
    	// This method accepts an NebulaCallback instance thus
    	// providing the Callback mechanism
    	public void ProcessNebulaClassStarship(NebulaCallback callback)
    	{
      		foreach(Nebula nx in ships)
      		{
        		callback(nx);
      		}
    	}

	}
	
	class Program
	{
			
		private static void UpdateExpectancy(Nebula nx)
    	{
      		nx.expectancy *= 7;
      		Console.WriteLine("The starship {0}'s life expectancy increased to {1} with crew of {2}",nx.classif,nx.expectancy,nx.crew);
		}
		
		private static void ChangeClassificationToAssault(Nebula nx)
    	{
      		nx.classif = "Assault";
      		Console.WriteLine("The starship {0}'s life classification changed to {1}.", nx.classif);
		}
		
		private static void IncrementContractNumber(Nebula nx)
    	{
			int ContractNumber =0;
      		ContractNumber = nx.number;
      		nx.number = ContractNumber +=3;
      		Console.WriteLine("The starship {0}'s contract number is changed to {1}.",nx.classif, nx.number);
		}
		
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello Galaxy!");
			
			Nebula nx1 = new Nebula("Exlporer", "NCC-61795", 30, 100,7);
      		Nebula nx2 = new Nebula("Exlporer", "NCC-61796",30, 100, 12);
      		Nebula nx3 = new Nebula("Exlporer", "NCC-61797", 30, 100,9);

      		Nebula[] ships = new Nebula[3];
      		ships[0]= nx1;
      		ships[1]= nx2;
      		ships[2]= nx3;
      		
      		
      		Fleet FifthFleet = new Fleet(ships,"FifthFleet");
			
			foreach(Nebula nx in ships)
      		{
        		Console.WriteLine(nx.ToString());
      		}
			
			// creating the delegate instance
			Fleet.NebulaCallback nxCallback = new Fleet.NebulaCallback(UpdateExpectancy);

      		nxCallback += new Fleet.NebulaCallback(IncrementContractNumber);

      		Console.WriteLine("Updating Nebula class life expectancy and Classification n");
     		FifthFleet.ProcessNebulaClassStarship(nxCallback);

			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}