import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-root',
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'GEC';
  visibility = true;

  items = ['Item 1', 'Item 2', 'Item 3'];
  store: any;
   

  listener() {
    this.visibility = !this.visibility;
    console.log(this.visibility);
  }
}
