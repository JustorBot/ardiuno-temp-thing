//Global Variables
int baseLineTemp = 0;
int celsius = 0;
int fahrenheit = 0;

void setup(){
  
  pinMode(A0, INPUT);
  Serial.begin(9600);
  
  pinMode(2, OUTPUT);
  pinMode(3, OUTPUT);
  pinMode(4, OUTPUT);
  
}

void loop(){
  
  //set threshhold tempreture to activate our LEDs
  baseLineTemp = 40;
  
  //measure tempreture in celsius
  celsius = map(((analogRead(A0)-20)*3.04), 0, 1023, -40, 125);

  Serial.print(celsius);
  Serial.print("C, ");

  if(celsius < baseLineTemp){
    digitalWrite(2, LOW);
    digitalWrite(3, LOW);
    digitalWrite(4, LOW);
  }

  if(celsius >= baseLineTemp && celsius < baseLineTemp + 10){
    digitalWrite(2, LOW);
    digitalWrite(3, LOW);
    digitalWrite(4, HIGH);
  }

  if(celsius >= baseLineTemp + 10 && celsius < baseLineTemp + 50){
    digitalWrite(2, LOW);
    digitalWrite(3, HIGH);
    digitalWrite(4, HIGH);
  }

  if(celsius >= baseLineTemp + 50 && celsius < baseLineTemp + 100){
    digitalWrite(2, HIGH);
    digitalWrite(3, HIGH);
    digitalWrite(4, HIGH);
  }

  if(celsius >= baseLineTemp + 100){
    digitalWrite(2, HIGH);
    digitalWrite(3, HIGH);
    digitalWrite(4, HIGH);
  }

}