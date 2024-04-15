//Global Variables
int baseLineTemp = 0;
int celsius = 0;
int fahrenheit = 0;

//Define LED pins and the tempreture thresholds
const int numLEDs = 3;
int ledPins[numLEDs] = {4, 3, 2};
int thresholds[numLEDs] = {10, 50, 80}; //Adjustable

void setup(){
  
  pinMode(A0, INPUT);
  Serial.begin(9600);
  
    //Set pinMode
    for(int i = 0; i < numLEDs; i++) 
    {
        pinMode(ledPins[i], OUTPUT);
    }
  
}

void activateLEDs(int temp){
    for(int i = 0; i < numLEDs; i++)
    {
        if(temp >= baseLineTemp + thresholds[i])
        {
            digitalWrite(ledPins[i], HIGH);   
        }
        else
        {
            digitalWrite(ledPins[i], LOW);
        }
    }
}

void loop(){
  
  //set threshhold tempreture to activate our LEDs
  baseLineTemp = 40;
  
  //measure tempreture in celsius
  celsius = map(((analogRead(A0)-20)*3.04), 0, 1023, -40, 125);

  Serial.print(celsius);
  Serial.print("C, ");

 activateLEDs(celsius);

}