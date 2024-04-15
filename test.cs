const  int redLEDPin = 4;     // LED connected to digital pin 4
const int blueLEDPin  = 3;    // LED connected to digital pin 3
const int greenLEDPin  = 2;   // LED connected to digital pin 2

// room temperature in Celcius
const  float baselineTemp = 25.0;

const float baselineSens = 144;
const int TempSensor  = A0;  // pin with the temp sensor

int redValue = 0; // value to write to  the red LED
int greenValue = 0; // value to write to the green LED
int blueValue  = 0; // value to write to the blue LED

void setup() {
  // initialize  serial communications at 9600 bps:
  Serial.begin(9600);

  pinMode(greenLEDPin, OUTPUT);
  pinMode(redLEDPin,  OUTPUT);
  pinMode(blueLEDPin, OUTPUT);
}

void loop() {


  int sensorVal  = analogRead(TempSensor);
   // convert temp sensor reading from 0-1024  to analogWrite value from 0-255 
  float voltage = (sensorVal / 1024.0) * 5.0;
  
  
// Send the voltage level out the Serial port
  Serial.print("Volts:  ");
  Serial.print(voltage);
  
  // convert the voltage to temperature  in degrees C
  Serial.print(",  degrees C: ");
  float temperature = (voltage - .5) * 100;
  Serial.println(temperature);

  if (temperature < baselineTemp) {
    analogWrite(redLEDPin, 0);
    analogWrite(greenLEDPin,  127);
    analogWrite(blueLEDPin, 0);
  }else if (temperature >= baselineTemp  && temperature < baselineTemp + 5) {
    analogWrite(redLEDPin, 0);
    analogWrite(greenLEDPin,  255);
    analogWrite(blueLEDPin, 0);
  } 
  else if (temperature >= baselineTemp + 2 && temperature < baselineTemp  + 40) {
    analogWrite(redLEDPin, 225);
    analogWrite(greenLEDPin, 225);
    analogWrite(blueLEDPin,  33);
  } 
  else  if (temperature >= baselineTemp + 4 && temperature < baselineTemp + 70) {
    analogWrite(redLEDPin,  225);
    analogWrite(greenLEDPin, 188);
    analogWrite(blueLEDPin, 0);
  } 
  else if (temperature  >= baselineTemp + 90) {
    analogWrite(redLEDPin, 255);
    analogWrite(greenLEDPin,  0);
    analogWrite(blueLEDPin, 0);
  }
}

