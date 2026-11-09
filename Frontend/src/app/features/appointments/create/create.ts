import { Component, EventEmitter, Output, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AppointmentService } from '../../../core/services/appointment.service';
import { CreateAppointmentCommand } from '../../../core/api/models';

@Component({
  selector: 'app-appointment-create',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './create.html',
  styleUrl: './create.css',
})
export class Create {
  private fb = inject(FormBuilder);
  private appointmentService = inject(AppointmentService);

  @Output() created = new EventEmitter<void>();
  @Output() cancelled = new EventEmitter<void>();

  isSubmitting: boolean = false;
  errorMessage: string = '';

  createForm: FormGroup = this.fb.group({
    appoinmentDate: ['', Validators.required],
    doctorId: ['', Validators.required],
    medicalDepartmentId: ['', Validators.required],
    patientId: ['', Validators.required],
  });

  onSubmit(): void {
    if (this.createForm.invalid) {
      this.createForm.markAllAsTouched();
      return;
    }

    this.isSubmitting = true;
    this.errorMessage = '';

    const command: CreateAppointmentCommand = this.createForm.value;

    this.appointmentService.createNewAppointment(command).subscribe({
      next: () => {
        this.isSubmitting = false;
        this.created.emit();
      },
      error: (err) => {
        console.error('Failed to create appointment', err);
        this.isSubmitting = false;
        this.errorMessage = 'Failed to create appointment. Please verify your inputs.';
      },
    });
  }

  onCancel(): void {
    this.cancelled.emit();
  }
}
