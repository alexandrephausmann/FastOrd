import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: `app.component.html`,
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  menuOpened = true;

  setMenuState(state: boolean) {
    this.menuOpened = state;
  }
}
