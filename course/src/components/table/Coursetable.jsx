import React from 'react';
import '../table/Table.css';
import Select from 'react-select';


const options = [
  { value: null, label: 'Spalte auswählen...' },
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

export default class Coursetable extends React.Component {
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
    const selectedValues = Object.values(this.state)
    var isDuplicate = false;
    selectedValues.forEach(selectedValue => {
      if (selectedValue === value.value && value.value !== null) {
        alert("Spalte bereits ausgewählt!")
        isDuplicate = true;
      }
    })

    if (!isDuplicate) {
      this.setState({
        [key]: value.value
      })
    }
  }

  onUpload = () => {
    if (!this.state.title || !this.state.category || !this.state.created) {
      alert("Die mit * gekennzeichneten Felder sind Pflichtfelder!")
      return;
    }

    const stateToSend = {
      title: this.state.title,
      courseNumber: this.state.courseNumber,
      discription: this.state.discription,
      category: this.state.category,
      start: this.state.start,
      end: this.state.end,
      unit: this.state.unit,
      price: this.state.price,
      classroomId: this.state.classroomId,
      participantsMax: this.state.participantsMax,
      participantsMin: this.state.participantsMin,
      created: this.state.created,
      modified: this.state.modified
    }

    this.props.upload(stateToSend);
  }

  render() {

    return (
      <div>
        <div className="tableHead">KURSE</div>
        <table className="table">
          <tbody>
            <tr>
              <td>Kurstitel *</td>
              <td><Select
                name="title"
                value={options.find(option => option.value === this.state.title)}
                onChange={(newValue) => this.handleChange('title', newValue)}
                options={options}
              /></td>
            </tr>
            <tr>
              <td>Kursnummer</td>
              <td><Select
                name="courseNumber"
                value={options.find(option => option.value === this.state.courseNumber)}
                onChange={(newValue) => this.handleChange('courseNumber', newValue)}
                options={options}
              /></td>
            </tr>
            <tr>
              <td>Kursbeschreibung</td>
              <td><Select
                name="discription"
                value={options.find(option => option.value === this.state.discription)}
                onChange={(newValue) => this.handleChange('discription', newValue)}
                options={options}
              /></td>
            </tr>
            <tr>
              <td>Kursinhalte *</td>
              <td><Select
                name="category"
                value={options.find(option => option.value === this.state.category)}
                onChange={(newValue) => this.handleChange('category', newValue)}
                options={options}
              /></td>
            </tr>
            <tr>
              <td>Kursbeginn</td>
              <td><Select
                name="start"
                value={options.find(option => option.value === this.state.start)}
                onChange={(newValue) => this.handleChange('start', newValue)}
                options={options}
              /></td>
            </tr>
            <tr>
              <td>Kursende</td>
              <td><Select
                name="end"
                value={options.find(option => option.value === this.state.end)}
                onChange={(newValue) => this.handleChange('end', newValue)}
                options={options}
              /></td>
            </tr>
            <tr>
              <td>Unterrichtseinheiten</td>
              <td><Select
                name="unit"
                value={options.find(option => option.value === this.state.unit)}
                onChange={(newValue) => this.handleChange('unit', newValue)}
                options={options}
              /></td>
            </tr>
            <tr>
              <td>Kursbeitrag</td>
              <td><Select
                name="price"
                value={options.find(option => option.value === this.state.price)}
                onChange={(newValue) => this.handleChange('price', newValue)}
                options={options}
              /></td>
            </tr>
            <tr>
              <td>Raum</td>
              <td><Select
                name="classroomId"
                value={options.find(option => option.value === this.state.classroomId)}
                onChange={(newValue) => this.handleChange('classroomId', newValue)}
                options={options}
              /></td>
            </tr>
            <tr>
              <td>max. Teilnehmerzahl</td>
              <td><Select
                name="participantsMax"
                value={options.find(option => option.value === this.state.participantsMax)}
                onChange={(newValue) => this.handleChange('participantsMax', newValue)}
                options={options}
              /></td>
            </tr>
            <tr>
              <td>min. Teilnehmerzahl</td>
              <td><Select
                name="participantsMin"
                value={options.find(option => option.value === this.state.participantsMin)}
                onChange={(newValue) => this.handleChange('participantsMin', newValue)}
                options={options}
              /></td>
            </tr>
            <tr>
              <td>erstellt am *</td>
              <td><Select
                name="created"
                value={options.find(option => option.value === this.state.created)}
                onChange={(newValue) => this.handleChange('created', newValue)}
                options={options}
              /></td>
            </tr>
            <tr>
              <td>abgeändert am</td>
              <td><Select
                name="modified"
                value={options.find(option => option.value === this.state.modified)}
                onChange={(newValue) => this.handleChange('modified', newValue)}
                options={options}
              /></td>
            </tr>
          </tbody>
        </table>
        <div type="button" className="button" onClick={() => this.onUpload()}>Upload</div>
      </div>
    )
  }
}