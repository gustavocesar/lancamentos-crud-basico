import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { map } from 'rxjs/operators';
import { catchError } from 'rxjs/internal/operators/catchError';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class WebApiService {
  constructor(private httpClient: HttpClient, private toastr: ToastrService) {}

  _httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Cache-Control': 'no-cache',
      Pragma: 'no-cache',
    }),
    observe: 'response' as 'body',
  };

  get(url: string): Observable<any> {
    return this.httpClient.get(url, this._httpOptions).pipe(
      map((response: any) => this.ReturnResponseData(response)),
      catchError(this.handleError)
    );
  }

  post(url: string, model: any): Observable<any> {
    return this.httpClient.post(url, model, this._httpOptions).pipe(
      map((response: any) => this.ReturnResponseData(response)),
      catchError(this.handleError)
    );
  }

  put(url: string, model: any): Observable<any> {
    return this.httpClient.put(url, model, this._httpOptions).pipe(
      map((response: any) => this.ReturnResponseData(response)),
      catchError(this.handleError)
    );
  }

  delete(url: string): Observable<any> {
    return this.httpClient.delete(url, this._httpOptions).pipe(
      map((response: any) => this.ReturnResponseData(response)),
      catchError(this.handleError)
    );
  }

  private ReturnResponseData(response: any) {
    return response;
  }

  public handleError = (response: any) => {
    const message = response?.error?.message;
    const data = response?.error?.data || '';
    
    let errors = '';
    for (let index = 0; index < data.length; index++) {
      const element = data[index];
      errors += ` - ${element.message}.<br />`;
    }

    this.toastr.error(errors, message);

    return throwError(response);
  };
}
