import React from 'react';
import './Fileinput.css';
import Select from 'react-select';


const options = [
  { value: null, label: 'keine Auswahl' },
  { value: '0', label: 'Spalte 1' },
  { value: '1', label: 'Spalte 2' },
  { value: '2', label: 'Spalte 3' },
  { value: '3', label: 'Spalte 4' },
  { value: '4', label: 'Spalte 5' },
  { value: '5', label: 'Spalte 6' },
  { value: '6', label: 'Spalte 7' },
  { value: '7', label: 'Spalte 8' },
  { value: '8', label: 'Spalte 9' },
  { value: '9', label: 'Spalte 10' },
  { value: '10', label: 'Spalte 11' },
  { value: '11', label: 'Spalte 12' },
  { value: '12', label: 'Spalte 13' },
];

export default class Fileinput extends React.Component {
  constructor(props) {
    super(props)
    this.state = {

      title: null,
      courseNumber: null,
      discription: null,
      category: null,
      start: null,
      end: null,
      unit: null,
      price: null,
      classroomId: null,
      participantsMax: null,
      participantsMin: null,
      created: null,
      modified: null
    }
  };


  handleChange = (key, value) => {
    console.log(value)
    this.setState({
      [key]: value.value
    })
  }

  render() {

    return (
      <div className="file-container">
        <table className="table">
          <tr>
            <td>Kurstitel *</td>
            <td><Select
              name="title"             
              onChange={(newValue) => this.handleChange('title', newValue)}
              options={options}
            /></td>
          </tr>
          <tr>
            <td>Kursnummer</td>
            <td><Select
              name="course_number"             
              onChange={(newValue) => this.handleChange('course_number', newValue)}
              options={options}
            /></td>
          </tr>
          <tr>
            <td>Kursbeschreibung</td>
            <td><Select
              name="discription"             
              onChange={(newValue) => this.handleChange('discription', newValue)}
              options={options}
            /></td>
          </tr>
          <tr>
            <td>Kursinhalte *</td>
            <td><Select
              name="category"             
              onChange={(newValue) => this.handleChange('category', newValue)}
              options={options}
            /></td>
          </tr>
          <tr>
            <td>Kursbeginn</td>
            <td><Select
              name="start"              
              onChange={(newValue) => this.handleChange('start', newValue)}
              options={options}
            /></td>
          </tr>
          <tr>
            <td>Kursende</td>
            <td><Select
              name="end"             
              onChange={(newValue) => this.handleChange('end', newValue)}
              options={options}
            /></td>
          </tr>
          <tr>
            <td>Unterrichtseinheiten</td>
            <td><Select
              name="unit"              
              onChange={(newValue) => this.handleChange('unit', newValue)}
              options={options}
            /></td>
          </tr>
          <tr>
            <td>Kursbeitrag</td>
            <td><Select
              name="price"              
              onChange={(newValue) => this.handleChange('price', newValue)}
              options={options}
            /></td>
          </tr>
          <tr>
            <td>Raum</td>
            <td><Select
              name="classroom_id"             
              onChange={(newValue) => this.handleChange('classroom_id', newValue)}
              options={options}
            /></td>
          </tr>
          <tr>
            <td>max. Teilnehmerzahl</td>
            <td><Select
              name="participant_max"
              onChange={(newValue) => this.handleChange('participant_max', newValue)}
              options={options}
            /></td>
          </tr>
          <tr>
            <td>min. Teilnehmerzahl</td>
            <td><Select
              name="participant_min"
              onChange={(newValue) => this.handleChange('participant_min', newValue)}
              options={options}
            /></td>
          </tr>
          <tr>
            <td>erstellt am *</td>
            <td><Select
              name="created@"
              onChange={(newValue) => this.handleChange('created', newValue)}
              options={options}
            /></td>
          </tr>
          <tr>
            <td>abgeändert am</td>
            <td><Select
              name="modified@"
              onChange={(newValue) => this.handleChange('modified', newValue)}
              options={options}
            /></td>
          </tr>
        </table>
        <div type="button" className="button" onClick={() => this.props.upload(this.state)}>Upload</div>
      </div>
    )
  }
}