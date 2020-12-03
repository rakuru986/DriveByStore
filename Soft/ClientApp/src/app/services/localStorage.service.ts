import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class LocalStorageService {
  localStorage: Storage;

  items = [];

  constructor() {
    this.localStorage = window.localStorage;
  }

  get(key: string): any {
    if (this.isLocalStorageSupported) {
      return JSON.parse(this.localStorage.getItem(key));
    }
    return null;
  }

  set(key: string, value: any): boolean {
    
    if (this.isLocalStorageSupported) {
      this.items = value;
      this.localStorage.setItem(key, JSON.stringify(value));
      return true;
    }
    return false;
  }

  remove(key: string, value: any): boolean {
    if (this.isLocalStorageSupported) {
      this.items = value;
      this.localStorage.removeItem(key);
      this.localStorage.setItem(key, JSON.stringify(this.items));
      return true;
    }
    return false;
  }

  get isLocalStorageSupported(): boolean {
    return !!this.localStorage;
  }
  
}
