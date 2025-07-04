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
clickher() {
throw new Error('Method not implemented.');
}
  protected title = 'GEC';
  visibility = true;

  items = ['Item 1', 'Item 2', 'Item 3'];
  store: any;


  listener() {
    console.log(this.visibility);
  }
}
