import { Component, Input, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppointmentService } from '../../../core/services/appointment.service';
import { AppointmentDto } from '../../../core/api/models';

@Component({
  selector: 'app-appointment-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './get.html',
  styleUrl: './get.css',
})
export class Get implements OnInit {
  private appointmentService = inject(AppointmentService);

  @Input() appointmentId!: string;

  appointment?: AppointmentDto;
  isLoading: boolean = true;
  errorMessage: string = '';

  ngOnInit(): void {
    if (this.appointmentId) {
      this.loadAppointmentDetails();
    }
  }

  loadAppointmentDetails(): void {
    this.isLoading = true;
    this.appointmentService.getAppointmentById(this.appointmentId).subscribe({
      next: (data) => {
        this.appointment = data;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Failed to load appointment details', err);
        this.errorMessage = 'Failed to load appointment details.';
        this.isLoading = false;
      },
    });
  }
}
