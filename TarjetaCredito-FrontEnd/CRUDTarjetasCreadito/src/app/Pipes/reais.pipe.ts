import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'reaisPipe'
})
export class ReaisPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return "R$      " + value ;
  }

}
