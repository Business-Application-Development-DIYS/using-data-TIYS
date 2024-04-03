using Classes;
using System.Xml;
using System.Text.Json;

List<Robot> robotList = new List<Robot>{};



menu();



void menu(){

    Console.WriteLine("Welcome, would you like to import data from XML or JSON?\n1: XML\n2: JSON");

    int choice = Convert.ToInt32(Console.ReadLine());

    if(choice == 1){
        importXML();

    }
    else if(choice == 2){
        importJSON();

    }
    else{
        Console.WriteLine("Invalid choice. Goodbye.");
        
    }

}

void robotQuery(){
    //Print all names of robots in the robotList
    for(int x = 0; x < robotList.Count(); x++){
        Console.WriteLine($"--======Robot {x + 1}======--");
        Console.WriteLine($"Robot ID: {robotList[x].RobotID}");
        Console.WriteLine($"Robot Name: {robotList[x].Name}"); 
        Console.WriteLine($"Robot Color: {robotList[x].Color}"); 
        Console.WriteLine($"Robot Battery Level: {robotList[x].BatteryLevel * 100}%");  

    }
}



void importJSON(){
    string jsonPath = @"E:\College\Tutoring\using-data-TIYS\tiys_xml_json_jbangtson\data\robot.json";

    string robotDataString = File.ReadAllText(jsonPath);

    RobotRoot roboRoot = JsonSerializer.Deserialize<RobotRoot>(robotDataString);

    robotList = roboRoot.Robots;



    robotQuery();
}



void importXML(){

XmlDocument studentDataDoc = new XmlDocument();
        XmlDocument robotDataDoc = new XmlDocument();

        string xmlPath = @"E:\College\Tutoring\using-data-TIYS\tiys_xml_json_jbangtson\data\robot.xml";

        robotDataDoc.Load(xmlPath);

        foreach(XmlNode nodeRobot in robotDataDoc.DocumentElement.ChildNodes)
        {
            // Temporary variables to house the data for each loop
            int robotid = 0;
            string name = "";
            string color = "";
            double batterylvl = 0.0;
            

            foreach(XmlNode nodeElement in nodeRobot)
            {
                
                switch(nodeElement.Name)
                {
                    case "robotid":
                        robotid = Convert.ToInt32(nodeElement.InnerText);
                        break;
                    case "name":
                        name = nodeElement.InnerText;
                        break;
                    case "color":
                        color = nodeElement.InnerText;
                        break;
                    case "batterylevel":
                        batterylvl = Convert.ToDouble(nodeElement.InnerText);
                        break;
                }            
            }

            Robot newRobot = new Robot(name, color, batterylvl);
            robotList.Add(newRobot);


    }
    robotQuery();
}

