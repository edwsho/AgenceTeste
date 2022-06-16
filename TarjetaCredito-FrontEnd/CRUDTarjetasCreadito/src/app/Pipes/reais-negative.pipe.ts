import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'reaisNegative'
})
export class ReaisNegativePipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return "R$ -" + value ;
  }

}
