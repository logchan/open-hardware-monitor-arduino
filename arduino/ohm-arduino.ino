#include <LiquidCrystal.h>

LiquidCrystal lcd(12,11,5,4,3,2);
char c;

void setup()
{
  lcd.begin(16,2);
  lcd.print("Hello!");
  delay(3000);
  lcd.clear();
  Serial.begin(9600);
}

void loop()
{
  if (Serial.available() > 0) {
    delay(100);
    lcd.clear();
    lcd.setCursor(0, 0);
    while (Serial.available() > 0) {
      c = Serial.read();
      if (c == '\n') {
        lcd.setCursor(0, 1);
      }
      else {
        lcd.write(c);
      }
    }
  }
}

