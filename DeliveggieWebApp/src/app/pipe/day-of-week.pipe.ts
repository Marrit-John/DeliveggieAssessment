import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'dayOfWeek'
})
export class DayOfWeekPipe implements PipeTransform {
  private days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];

  transform(dayNumber: number): string {
    if (dayNumber >= 0 && dayNumber <= 6) {
      return this.days[dayNumber];  // Returns the correct day based on 0-6 (Sunday-Saturday)
    }
    return 'Invalid day';  // In case the number is out of range
  }
}