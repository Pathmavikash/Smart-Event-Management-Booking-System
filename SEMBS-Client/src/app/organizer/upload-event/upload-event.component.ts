import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { EventDTO } from '../../shared/models/events/event-model';
import { EventService } from '../../core/services/event-service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-upload-event',
  standalone: false,
  templateUrl: './upload-event.component.html',
  styleUrls: ['./upload-event.component.css']
})
export class UploadEventComponent implements OnInit {

  basicForm!: FormGroup;
  infoForm!: FormGroup;

  imagePreviews: string[] = [];
  isMobile = false;

  constructor(
    private fb: FormBuilder,
    private breakpointObserver: BreakpointObserver,
    private eventService: EventService,
    private snackBar: MatSnackBar,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.basicForm = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      venue: ['', Validators.required]
    });

    this.infoForm = this.fb.group({
      capacity: [1, Validators.required],
      eventDate: ['', Validators.required],
      price: [0, Validators.required]
    });

    this.breakpointObserver
      .observe([Breakpoints.Handset])
      .subscribe(result => {
        this.isMobile = result.matches;
      });
  }

  onImageSelect(event: any): void {
    const files = event.target.files;
    this.imagePreviews = [];

    for (let file of files) {
      const reader = new FileReader();
      reader.onload = () => this.imagePreviews.push(reader.result as string);
      reader.readAsDataURL(file);
    }
  }

  submitEvent(): void {
    if (this.basicForm.invalid || this.infoForm.invalid) return;

    const eventPayload = {
      ...this.basicForm.value,
      ...this.infoForm.value,
      images: this.imagePreviews
    };

    const eventDtls: EventDTO = {
      title: this.basicForm.value.title,
      description: this.basicForm.value.description,
      date: this.infoForm.value.eventDate,
      venue: this.basicForm.value.venue,
      capacity: this.infoForm.value.capacity,
      organizerId: this.getOrgainzerId(),
      price: this.infoForm.value.price
    };

    this.eventService.createEvent(eventDtls).subscribe({
      next: (res) => {
        this.snackBar.open('Event created successfully ✅', 'Close', { duration: 2000 });
        //this.router.navigate(['/organizer/events']);
      },
      error: (err) => {
        console.error('Registration failed', err);
        this.snackBar.open('Registration failed ❌', 'Close', { duration: 2500 });
      }
    });
  }

  getOrgainzerId(): number {
    const organizerId = localStorage.getItem('userId');
    return organizerId ? parseInt(organizerId, 10) : 0;
  }
}
