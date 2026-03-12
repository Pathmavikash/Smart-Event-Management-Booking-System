import { Component, OnInit } from "@angular/core";
import { EventService } from "../../core/services/event-service";
import { Router } from "@angular/router";
import { EventDTO } from "../../shared/models/events/event-model";

@Component({
    selector: 'app-manage-events',
    standalone: false,
    templateUrl: './manage-event.component.html',
    styleUrls: ['./manage-event.component.css']
})
export class ManageEventsComponent implements OnInit {
    events: EventDTO[] = [];
    isLoading = false;
    errorMessage = '';

    constructor(private eventService: EventService, private router: Router) { }
    
    ngOnInit(): void {
        this.loadMyEvents()
    }

    loadMyEvents(): void {
        this.isLoading = true;
        const organizerId = this.getOrgainzerId();
        this.eventService.getMyEvents(organizerId).subscribe({
            next: (res) => {
                this.events = res;
                this.isLoading = false;
            },
            error: () => {
                this.errorMessage = 'Failed to load your events';
                this.isLoading = false;
            }
        });

    }
    editEvent(event: EventDTO): void {
        this.router.navigate(['/organizer/events/edit', event]);
    }
    getOrgainzerId(): number {
    const organizerId = localStorage.getItem('userId');
    return organizerId ? parseInt(organizerId, 10) : 0;
  }
}