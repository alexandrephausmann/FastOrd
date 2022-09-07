import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  @Output() menuToggle: EventEmitter<boolean> = new EventEmitter();
  @Input() opened = false;

  constructor() { }

  ngOnInit(): void {
  }

  toggle() {

    this.opened = !this.opened;
    this.menuToggle.emit(this.opened);
  }

  toggleMenu() {

    this.opened = true;
    this.menuToggle.emit(true);
  }

}
