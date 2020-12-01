import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TextModel } from './text.model';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TextHttpServiceService {

  constructor(private http: HttpClient) { }

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: 'my-auth-token'
    })
  };

  getTextFromDb() {
    const url = 'https://localhost:44397/word/getfromdb';
    const result = this.http.get<TextModel>(url)
      .pipe(catchError(e => this.handleError(e)));

    return result;
  }

  getTextFromFile() {
    const url = 'https://localhost:44397/word/getfromfile';
    const result = this.http.get<TextModel>(url)
      .pipe(catchError(e => this.handleError(e)));

    return result;
  }


  calculateNumberOfWords(text: TextModel) {
    const url = 'https://localhost:44397/word/calculateNumberOfWords';
    //const url = 'https://localhost:44397/word/toper';

    return this.http.post<TextModel>(url, text, this.httpOptions)
      .pipe(catchError(e => this.handleError(e)));
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // Return an observable with a user-facing error message.
    return throwError(
      'Something bad happened; please try again later.');
  }
}
