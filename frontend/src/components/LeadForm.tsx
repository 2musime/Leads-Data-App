import { useState } from 'react';
import type Lead from '../types/Lead';
import './LeadForm.css';

const initialFormState: Lead = {
  title: '',
  industry: '',
  region: '',
};

const LeadForm = () => {
  const [form, setForm] = useState<Lead>(initialFormState);

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value } = e.target;
    setForm(prev => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const response = await fetch('https://localhost:7188/api/LeadsInputs', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(form),
      });

      if (!response.ok) {
        throw new Error('Server error');
      }

      alert('Lead submitted successfully');
      setForm(initialFormState);
    } catch (error) {
      alert('Error submitting lead');
      console.error(error);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="lead-form">
      <h2 className="lead-form-title">Get Started Today</h2>
      <p className="lead-form-subtitle">
        Tell us about your business and we'll help you grow
      </p>

      <input
        name="title"
        value={form.title}
        onChange={handleChange}
        placeholder="e.g., Digital Marketing Strategy"
        className="lead-form-input"
        required
      />

      <input
        name="industry"
        value={form.industry}
        onChange={handleChange}
        placeholder="Technology, Finance, Education"
        className="lead-form-input"
        required
      />

      <input
        name="region"
        value={form.region}
        onChange={handleChange}
        placeholder="Kigali, Rwanda"
        className="lead-form-input"
        required
      />

      <button type="submit" className="lead-form-button">
        Submit Lead Information
      </button>

      <p className="lead-form-footer">
        By submitting this form, you agree to our terms of service and privacy
        policy.
      </p>
    </form>
  );
};

export default LeadForm;
