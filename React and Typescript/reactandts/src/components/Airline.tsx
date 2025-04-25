import React, { useState, useEffect } from 'react';
import { CircularProgress, Grid, TextField, Button, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper } from '@mui/material';
import axios, { AxiosResponse } from 'axios';
import { Booking, BookingsResponse } from './interfaces';

const Forms: React.FC = () => {
  const [bookings, setBookings] = useState<Booking[]>([]);
  const [formData, setFormData] = useState<Booking>({
    name: '',
    flightNumber: 0,
    departureDate: '',
    seatNumber: 0,
  });
  const [editingId, setEditingId] = useState<number | null>(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    fetchBookings();
  }, []);

  const fetchBookings = async () => {
    setLoading(true);
    try {
      const response: AxiosResponse<BookingsResponse> = await axios.get('http://localhost:3000/data');
      setBookings(response.data.bookings);
    } catch (error) {
      console.log(error);
    } finally {
      setLoading(false);
    }
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (editingId === null) {
      try {
        const response: AxiosResponse<Booking> = await axios.post('http://localhost:3000/data', formData);
        setBookings([...bookings, response.data]);
        setFormData({
          name: '',
          flightNumber: 0,
          departureDate: '',
          seatNumber: 0,
        });
      } catch (error) {
        console.log(error);
      }
    } else {
      try {
        const response: AxiosResponse<Booking> = await axios.put(`http://localhost:3000/data/${editingId}`, formData);
        const updatedBookings = bookings.map(booking => {
          if (booking.id === response.data.id) {
            return response.data;
          }
          return booking;
        });
        setBookings(updatedBookings);
        setFormData({
          name: '',
          flightNumber: 0,
          departureDate: '',
          seatNumber: 0,
        });
        setEditingId(null);
      } catch (error) {
        console.log(error);
      }
    }
  };

  const handleEdit = (booking: Booking) => {
    setFormData({ ...booking });
    setEditingId(booking.id ?? null);
  };

  const handleDelete = async (id?: number) => {
    if (id !== undefined) {
      try {
        await axios.delete(`http://localhost:3000/data/${id}`);
        const updatedBookings = bookings.filter(booking => booking.id !== id);
        setBookings(updatedBookings);
      } catch (error) {
        console.log(error);
      }
    }
  };

  return (
    <Grid container spacing={2}>
      <Grid item xs={12}>
        <Paper>
          <form onSubmit={handleSubmit} className="user-form">
            <Grid container spacing={2}>
              <Grid item xs={12} sm={6}>
                <TextField
                  label="Passenger Name"
                  name="name"
                  value={formData.name}
                  onChange={handleChange}
                  fullWidth
                  required
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField
                  label="Flight Number"
                  name="flightNumber"
                  type="number"
                  value={formData.flightNumber}
                  onChange={handleChange}
                  fullWidth
                  required
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField
                  label="Departure Date"
                  name="departureDate"
                  type="date"
                  value={formData.departureDate}
                  onChange={handleChange}
                  fullWidth
                  required
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField
                  label="Seat Number"
                  name="seatNumber"
                  type="number"
                  value={formData.seatNumber}
                  onChange={handleChange}
                  fullWidth
                  required
                />
              </Grid>
            </Grid>
            <Button type="submit" variant="contained" color="primary" fullWidth>
              {editingId ? 'Update' : 'Book'}
            </Button>
          </form>
        </Paper>
      </Grid>
      <Grid item xs={12}>
        <Paper>
          <TableContainer component={Paper}>
            <Table aria-label="simple table">
              <TableHead>
                <TableRow>
                  <TableCell>Booking ID</TableCell>
                  <TableCell>Passenger Name</TableCell>
                  <TableCell>Flight Number</TableCell>
                  <TableCell>Departure Date</TableCell>
                  <TableCell>Seat Number</TableCell>
                  <TableCell>Actions</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {bookings.map(booking => (
                  <TableRow key={booking.id}>
                    <TableCell>{booking.id}</TableCell>
                    <TableCell>{booking.name}</TableCell>
                    <TableCell>{booking.flightNumber}</TableCell>
                    <TableCell>{booking.departureDate}</TableCell>
                    <TableCell>{booking.seatNumber}</TableCell>
                    <TableCell>
                      <Button onClick={() => handleEdit(booking)}>Edit</Button>
                      <Button onClick={() => handleDelete(booking.id)}>Delete</Button>
                    </TableCell>
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </TableContainer>
          {loading && <CircularProgress />}
        </Paper>
      </Grid>
    </Grid>
  );
};

export default Forms;

