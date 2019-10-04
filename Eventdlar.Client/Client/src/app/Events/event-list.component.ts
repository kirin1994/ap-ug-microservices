import {Component} from '@angular/core'
import {Eventer} from './eventer'
import {Observable, of, combineLatest} from 'rxjs'
import { map , filter} from 'rxjs/operators'
import {FormControl} from '@angular/forms'



@Component({
  templateUrl: './event-list.component.html'
})
export class EventListComponent{
  
  filter: FormControl = new FormControl('');
  filter$: Observable<string> = this.filter.valueChanges;
  events : Observable<Eventer[]> = of<Eventer[]>([
    { description : "adadaxax", name : "Test1" },
    { description : "adadaxax", name : "Test2" },
    { description : "adadaxax", name : "Test3" },
    { description : "adadaxax", name : "Test4" }
  ]);
  filteredEvents: Observable<Eventer[]> = combineLatest(this.events, this.filter$).pipe(map(([evento, filter])=> evento.filter(event => event.name.indexOf(filter) !== -1)))
}