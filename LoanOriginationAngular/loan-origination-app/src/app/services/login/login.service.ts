import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private apiUrl = 'http:/api/Account';

  constructor(private http: HttpClient) { }

  login(username: string, pin: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/Login/${username}/${pin}`, {});
  }
}
