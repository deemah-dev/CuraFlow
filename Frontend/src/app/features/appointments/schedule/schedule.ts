import { Component, Input, Output, EventEmitter, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AppointmentService } from '../../../core/services/appointment.service';
import { ScheduleAppointmentCommand } from '../../../core/api/models';

@Component({
  selector: 'app-appointment-schedule',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './schedule.html',
  styleUrl: './schedule.css',
})
export class Schedule {
  private fb = inject(FormBuilder);
  private appointmentService = inject(AppointmentService);

  @Input() appointmentId!: string;
  @Output() rescheduled = new EventEmitter<void>();
  @Output() cancelled = new EventEmitter<void>();

  isSubmitting: boolean = false;
  errorMessage: string = '';

  scheduleForm: FormGroup = this.fb.group({
    newAppointmentDate: ['', Validators.required],
  });

  onSubmit(): void {
    if (this.scheduleForm.invalid || !this.appointmentId) {
      this.scheduleForm.markAllAsTouched();
      return;
    }

    const selectedDate = new Date(this.scheduleForm.value.newAppointmentDate);
    const now = new Date();

    if (selectedDate <= now) {
      this.errorMessage = 'The new appointment date must be in the future.';
      return;
    }

    this.isSubmitting = true;
    this.errorMessage = '';

    const command: ScheduleAppointmentCommand = {
      appointmentId: this.appointmentId,
      newAppointmentDate: this.scheduleForm.value.newAppointmentDate,
    };

    this.appointmentService.scheduleAppointment(this.appointmentId, command).subscribe({
      next: () => {
        this.isSubmitting = false;
        this.rescheduled.emit();
      },
      error: (err) => {
        console.error('Failed to reschedule appointment', err);
        this.isSubmitting = false;
        this.errorMessage = 'Failed to reschedule appointment. Please try again.';
      },
    });
  }

  onCancel(): void {
    this.cancelled.emit();
  }
}
