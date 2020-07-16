import React from 'react';
import './Fileinput.css';
import Select from 'react-select';

let options = [];
export default class Fileinput extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            properties: props.properties
        }         
    }
    static getDerivedStateFromProps(nextProps, prevState) {
        if (nextProps.properties !== prevState.properties) {
            return { properties: nextProps.properties }
        }
    }

    createOptions() {
        options = [{ value: null, label: 'Spalte auswählen ...' }]
        for(var i = 0; i < this.state.properties.length; i++) {
            options.push({value: i, label: 'Spalte '+ (+i + 1)})
            console.log(options);    
        }
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
        var popup = false;
        this.state.properties.forEach(prop => {
            if (prop.required) {
                if (prop.columnValue === null) {
                    popup = true
                }
            }
        })
        if (popup) {
            alert("Die mit * gekennzeichneten Felder sind Pflichtfelder!")
            return
        }
        this.props.upload(this.state.properties)
        
        
        
    }
    render() {
        console.log(this.state)
        return (
            <div className="input-container">
            {this.createOptions()}
                <table>
                    <tbody>
                        {this.state.properties.map((newState) => {
                            var value = options.find(option => option.value === newState.columnValue)
                            var x = newState.required ? "*" : "";
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
                <div type="button" className="button-click" onClick={() => this.onUpload()} >Upload</div>
            </div>
        )
    }
}