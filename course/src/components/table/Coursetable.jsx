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
  { value: '13', label: 'Spalte 14' },
  { value: '14', label: 'Spalte 15' },
  { value: '15', label: 'Spalte 16' },
  { value: '16', label: 'Spalte 17' },
  { value: '17', label: 'Spalte 18' },
  { value: '18', label: 'Spalte 19' },
  { value: '19', label: 'Spalte 20' }
];

export default class Coursetable extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      properties2: props.courseFields
     
    }
  };


  handleChange = (key, value) => {
    const selectedValues = Object.values(this.state.properties2)
    var isDuplicate = false;
    selectedValues.forEach(selectedValue => {
      if (value.value !== null && selectedValue.columnValue === value.value) {
        alert("Spalte bereits ausgewählt!")
        isDuplicate = true;
      }
    })

    if (!isDuplicate) {
        const currentState = this.state.properties2;
        const fieldToUpdate = currentState.find(field => field.propName === key)
        fieldToUpdate.columnValue = value.value

        this.setState({
            properties2: currentState
      })
    }
  }

  onUpload = () => {
    var popup = false;

    this.state.properties2.forEach(prop => {
        if(prop.required) {
            if(prop.columnValue === null) {
                popup = true       
            }
        }
    })

    if(popup) {
        alert("Die mit * gekennzeichneten Felder sind Pflichtfelder!")
        return
    }

    this.props.upload(this.state.properties2)
}
  render() {

    return (
      <div>
        <div className="tableHead">KURSE</div>
        <table className="table">
          <tbody>
            {this.state.properties2.map((newState) => {
              var value = options.find(option => option.value === newState.columnValue)
              var x = newState.required ? " *" : "";
              return (
                <tr>
                  <td>{newState.displayName + x}</td>
                  <td><Select
                    value={value}
                    onChange={(newValue) => this.handleChange(newState.propName, newValue)}
                    options={options}
                  /></td>
                </tr>
              )
            }
            )}
          </tbody>
        </table>
        <div type="button" className="button" onClick={() => this.onUpload()}>Upload</div>
      </div>
    )
  }
}