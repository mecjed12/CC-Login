import React from 'react';
import '../Dropdown/Dropdown.css';
import Select from 'react-select';


const options = [
    { value: true, label: 'Kurse' },
    { value: false, label: 'Personen' },
];

export default class Dropdown extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            selectionOption: null,
        }
    }
    
    handelchange = selectionOption => {
        this.setState(
            { selectionOption }
        );
        this.props.toggleClass(selectionOption.value)
    };
   
    render() {
        return (
            <div className="input-container">
                <table>
                    <tbody>
                        <tr>
                            <td><Select
                                value={this.state.selectionOption}
                                onChange={ this.handelchange}
                                options={options}
                            /></td>
                        </tr>
                    </tbody>
                </table>
            </div>


        )

    }
}