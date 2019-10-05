import {Component} from '@angular/core'
import {Eventer} from './eventer'
import {Observable, of, combineLatest} from 'rxjs'
import { map , filter} from 'rxjs/operators'
import {FormControl} from '@angular/forms'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { EventsList } from './events-list'



@Component({
  templateUrl: './event-list.component.html'
})
export class EventListComponent{
  constructor(private http: HttpClient){}
  filter: FormControl = new FormControl('');
  filter$: Observable<string> = this.filter.valueChanges;
  events : Observable<Eventer[]>;
  filteredEvents: Observable<Eventer[]>;

  ngOnInit(){
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8')
    headers = headers.set('Access-Control-Allow-Origin' , '*');

    let ip = window.location.hostname;
    let address = "http://" + ip + ":31001/api/gateway/events";
    console.log(address);  
    let req = this.http.get<EventsList>(address,{headers});
    console.log(req);
    this.filteredEvents = combineLatest(req, this.filter$).pipe(map(([evento, filter])=> evento.eventsList.filter(event => event.name.indexOf(filter) !== -1), console.log(event)))
  }
}