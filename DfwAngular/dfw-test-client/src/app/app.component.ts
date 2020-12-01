import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { TextHttpServiceService } from './text-http-service.service';
import { TextModel } from './text.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'dfw-test-client';

  public textFromDb: TextModel = new TextModel();
  public textFromFile: TextModel = new TextModel();
  public userEnteredText: TextModel = new TextModel();

  constructor(private service: TextHttpServiceService) {

  }
  ngOnInit(): void {
    this.service.getTextFromDb().subscribe(x => this.textFromDb = x);
    this.service.getTextFromFile().subscribe(x => this.textFromFile = x);
  }

  calculateNumberOfWords(text) {
    this.service.calculateNumberOfWords(text).subscribe(x => this.userEnteredText = x);
  }
}
