import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: [],
})
export class AppComponent {
  constructor() {}
  title = 'Angular7';
  currDiv: string = '';
  showHide = false;

  toggle() {
    this.showHide = !this.showHide;
  }

  showForm(divVal: string) {
    this.currDiv = divVal;
  }
}
