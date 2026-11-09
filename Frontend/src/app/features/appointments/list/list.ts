import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, inject, OnInit } from '@angular/core';
import { AppointmentService } from '../../../core/services/appointment.service';
import { AppointmentDto, PagenatedListOfAppointmentDto } from '../../../core/api/models';

@Component({
  selector: 'app-appointment-list',
  imports: [CommonModule],
  templateUrl: './list.html',
  styleUrl: './list.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class List implements OnInit {
  private appointmentService = inject(AppointmentService);

  appointments: PagenatedListOfAppointmentDto = {
    page: 1,
    size: 10,
    values: [
      {
        appoinmentDate: '',
        appointmentId: '',
        doctorId: '',
        medicalDepartmentId: '',
        patientId: '',
        status: 0,
      },
    ],
  };

  isLoading: boolean = true;
  errorMessage: string = '';

  ngOnInit(): void {
    this.loadAppointments();
  }

  loadAppointments(): void {
    this.isLoading = true;

    this.appointmentService.getAppointments().subscribe({
      next: (data) => {
        this.appointments = data;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('', err);
        this.errorMessage = '';
        this.isLoading = false;
      },
    });
  }

  onDelete(id: string | undefined): void {
    if (!id) return;

    if (confirm('Are you sure you want to delete this appointment?')) {
      this.appointmentService.deleteAppointment(id).subscribe({
        next: () => {
          this.loadAppointments();
        },
        error: (err) => {
          console.error('Failed to delete appointment', err);
          alert('Failed to delete appointment.');
        },
      });
    }
  }
}
