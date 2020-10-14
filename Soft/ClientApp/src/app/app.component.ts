import { Component } from '@angular/core';
import { ɵINTERNAL_BROWSER_DYNAMIC_PLATFORM_PROVIDERS } from '@angular/platform-browser-dynamic';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
}

export interface IProducts{
  name: string,
  manufactorer: string,
  price: number,
  picture: string,
  description: string;  
}