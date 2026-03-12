import { Component, OnInit } from '@angular/core';
import { EventService } from '../../core/services/event-service';
import { EventDTO } from '../../shared/models/events/event-model';


@Component({
  selector: 'app-event-list',
  standalone: false,
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.css']
})
export class EventListComponent implements OnInit {
  events: EventDTO[] = [];
  isLoading: boolean = true;

  constructor(private eventService: EventService) { }

  ngOnInit(): void {
    this.loadEvents();
  }

  loadEvents() {
    this.eventService.getAllEvents().subscribe({
      next: (data) => {
        this.events = data;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error fetching events', err);
        this.isLoading = false;
      }
    });
  }

  bookEvent(event: EventDTO) {
    console.log('Booking event:', event);
  }
}