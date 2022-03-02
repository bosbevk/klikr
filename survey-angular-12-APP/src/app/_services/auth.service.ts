import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const AUTH_API = 'https://localhost:5001/api/Login';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) { }
  login(username: string, password: string, firstname: string, lastname: string): Observable<any> {
    
    return this.http.post(AUTH_API, {
      username,
      firstname,
      lastname,
      password,
    }, httpOptions);
  }

  register(Username: string, Email: string, Password: string): Observable<any> {
    return this.http.post(AUTH_API + 'signup', {
      Username,
      Email,
      Password
    }, httpOptions);
  }
}
