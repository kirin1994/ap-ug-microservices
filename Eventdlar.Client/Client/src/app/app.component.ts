import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor (private http: HttpClient ) {}
  title = 'Client';

  onClickMe()
  { 
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8')
    headers = headers.set('Access-Control-Allow-Origin' , '*');

    this.http.get("webapi-service.default.svc.cluster.local/api/values", {headers}).subscribe(data => console.log(data));
  }
}
