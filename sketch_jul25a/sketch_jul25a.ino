
#include "SR04.h"
#define TRIG_PIN 12
#define ECHO_PIN 11
#define RED_LED 10
#define GREEN_LED 9

SR04 sr04 = SR04(ECHO_PIN, TRIG_PIN);

void setup() {
  pinMode(RED_LED, OUTPUT);
  pinMode(GREEN_LED, OUTPUT);
  Serial.begin(9600);
  delay(1000);
}


long distanceResult() {
  long distance = sr04.Distance();
  return distance;
}

bool productPresent(long distance) {
  long thresholdNoProduct = 10;
  if (distance >= thresholdNoProduct) {
    digitalWrite(RED_LED, HIGH);
    digitalWrite(GREEN_LED, LOW);
    return false; // Product not present
  } else {
    digitalWrite(GREEN_LED, HIGH);
    digitalWrite(RED_LED, LOW);
    return true; // Product present
  }
}

void loop() {
  long distance = distanceResult();
  bool currentProductState = productPresent(distance);
  Serial.print("Product present: ");
  Serial.println(currentProductState);
  delay(500);
}
