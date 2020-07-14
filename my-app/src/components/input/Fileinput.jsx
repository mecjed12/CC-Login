import React from 'react';
import './Fileinput.css';
import Select from 'react-select';

const options = [
    { value: null, label: 'Spalte auswählen ...' },
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
];
export default class Fileinput extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            properties: props.personFields
        }
        //this.onUpload = this.onUpload.bind(this);
      
    }
    handleChange = (key, value) => {
        //checkt die Spalten ab ob nicht die gleichen genommen wurde
        const selectedValues = Object.values(this.state.properties)
        var isDuplicate = false;
        selectedValues.forEach(selectedValue => {
            if (value.value !== null && selectedValue.columnValue === value.value) {
                alert("Spalte bereits ausgewählt!")
                isDuplicate = true;
            }
        })
        if (!isDuplicate) {
            const currentState = this.state.properties;
            const fieldToUpdate = currentState.find(field => field.propName === key)
            fieldToUpdate.columnValue = value.value

            this.setState({
                properties: currentState
            })
        }
    }
    onUpload = () => {
        // check for required fields
        // if (!this.state.name2) {
        //     alert("Bitte Feld ausfüllen")
        //     return  
        // }
        // ... all fields are filled
        // const stateToSend = {
        //     //finishdata = newState.propName,
        //     // name1: this.state.name1,
        //     // name2: this.state.name2,
        //     // title: this.state.title,
        //     // svNumber: this.state.svNumber,
        //     // date: this.state.date,
        //     // Gender: this.state.Gender,
        //     // busy: this.state.busy,
        //     // busy_by: this.state.busy_by,
        //     // picture: this.state.picture,
        //     // function: this.state.function,
        //     // email: this.state.email,
        //     // phoneNumber: this.state.phoneNumber,
        //     // street: this.state.street,
        //     // place: this.state.place,
        //     // country: this.state.country,
        //     // zipCode: this.state.zipCode
        // }
        this.props.upload(this.state.properties)
    }
    render() {
        console.log(this.state)
        return (
            <div className="input-container">
                <table>
                    <tbody>
                        {this.state.properties.map((newState) => {
                            var value = options.find(option => option.value === newState.columnValue)
                            var x = newState.required ? " *" : "";
                            return (
                                <tr>
                                    <td>{newState.displayName + x}</td>
                                    <td> <Select
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
                <div type="button" className="button-click" onClick={() => this.onUpload()}>Upload</div>
            </div>
        )
    }
}