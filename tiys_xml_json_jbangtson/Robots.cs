namespace Classes;

public class Robot
{
    
    

    /*
    We haven't talked about static, but mess around with it!
    I'm using it to increment as robots are created. 
    So the first robot will be robot 0, then the next one will be 1, and
    so on!
    */
    private static int robotID = 0;
    // Properties of Student

    public int RobotID{get; private set;}
    public string Name {get; set;}
    public string Color {get; set;}
    public double BatteryLevel {get; set;}


    // Constructor Method
    public Robot(string name, string color, double batterylevel)
    {
        RobotID = robotID;
        Name = name;
        Color = color;
        BatteryLevel = batterylevel;

        robotID =+ 1;
        checkBatteryLevel();
    }

    void checkBatteryLevel(){

        if(BatteryLevel > 1){
            BatteryLevel = 1;

        }
        else if(BatteryLevel < 0){
            BatteryLevel = 0;

        }
        
    }
   
    
    
}
