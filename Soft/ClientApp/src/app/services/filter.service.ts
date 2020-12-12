import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FilterService {

  constructor() { }
  numbers: Array<number>;
  // from: number;
  // to: number;

  set(from: number, to: number){    
    this.numbers = []
    if(from === null){
      //this.from = 0;
      this.numbers.push(0);
    }
    else{
      //this.from = from;
      this.numbers.push(from);
    }

    if(to === null){
      //this.to = 10000000
      this.numbers.push(1000000);
    }
    else{
      //this.to = to;
      this.numbers.push(to);
    }
    // console.log(this.from)
    // console.log(this.to)   
    console.log(this.numbers);
  }

  getFrom(): number{
    //console.log(this.from)
    // if(this.from===undefined){
    //   return 0;
    // }   
    console.log(this.numbers[0])
    return this.numbers[0];       
  }

  getTo(): number{  
    // console.log(this.to)  
    // if(this.to===undefined){
    //   return 10000000;
    // }
    console.log(this.numbers[1])
    return this.numbers[1];
  }
}
