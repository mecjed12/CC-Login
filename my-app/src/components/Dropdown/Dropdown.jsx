import React from 'react';
import '../Dropdown/Dropdown.css';
import Select from 'react-select';
import axios from 'axios';

let options = []
export default class Dropdown extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            selectionOption: null,
            properties: []
        }

        this.getProperties()
    }
    handelchange = selectionOption => {
        this.setState(
            { selectionOption }
        );
        this.props.toggleClass(selectionOption.value)
    };
    getProperties() {
        axios.get("http://192.168.0.94:8017/application/").then(res => {
            this.setState({
                properties: res.data
            })
        }).catch(err => console.log(err))
    }
    createOptions() {
        options = [{value: null, label: 'Spalte auswählen'}]
        for (var i = 0; i < this.state.properties.length; i++) {
            options.push({value: this.state.properties[i].name, label: this.state.properties[i].displayName})
        }
    }
  

    render() {
        return (
            <div className="input-container">
                {this.createOptions()}
                <table>
                    <tbody>
                        <tr>
                            <td><Select
                                value={this.state.selectionOption}
                                onChange={this.handelchange}
                                options={options}
                            /></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        )
    }
}