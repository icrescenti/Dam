#Exercici 2.4
from datetime import date, timedelta, datetime
import calendar

now = datetime.now()
inici = date(now.year, now.month, 1)
final = date(now.year, now.month, calendar.monthrange(now.year, now.month)[1])
dates = final - inici

print("Els dies del mes actual seran: ")
for i in range(dates.days + 1):
    print(inici + timedelta(days=i))