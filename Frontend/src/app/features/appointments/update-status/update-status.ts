import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  inject,
  Input,
  OnInit,
  Output,
} from '@angular/core';
import { AppointmentStatus, UpdateAppointmentStatusCommand } from '../../../core/api/models';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AppointmentService } from '../../../core/services/appointment.service';

@Component({
  selector: 'app-update-status',
  imports: [],
  template: `<p>update-status works!</p>`,
  styleUrl: './update-status.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UpdateStatus implements OnInit {
  private fb = inject(FormBuilder);
  private appointmentService = inject(AppointmentService);

  @Input() appointmentId!: string;
  @Input() currentStatus?: AppointmentStatus;

  @Output() statusUpdated = new EventEmitter<void>();
  @Output() cancelled = new EventEmitter<void>();

  isSubmitting: boolean = false;
  errorMessage: string = '';

  statusForm: FormGroup = this.fb.group({
    newStatus: ['', Validators.required],
  });

  ngOnInit(): void {
    if (this.currentStatus !== undefined) {
      this.statusForm.patchValue({ newStatus: this.currentStatus });
    }
  }

  onSubmit(): void {
    if (this.statusForm.invalid || !this.appointmentId) {
      this.statusForm.markAllAsTouched();
      return;
    }

    this.isSubmitting = true;
    this.errorMessage = '';

    const command: UpdateAppointmentStatusCommand = {
      appointmentId: this.appointmentId,
      newStatus: Number(this.statusForm.value.newStatus),
    };

    this.appointmentService.updateAppointmentStatus(this.appointmentId, command).subscribe({
      next: () => {
        this.isSubmitting = false;
        this.statusUpdated.emit();
      },
      error: (err) => {
        console.error('Failed to update appointment status', err);
        this.isSubmitting = false;
        this.errorMessage = 'Failed to update status. Please try again.';
      },
    });
  }

  onCancel(): void {
    this.cancelled.emit();
  }
}
