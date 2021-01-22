using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace CrestronModule_TSTATEX_SETBACK
{
    public class CrestronModuleClass_TSTATEX_SETBACK : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput INDEGF;
        Crestron.Logos.SplusObjects.DigitalInput INDEGC;
        Crestron.Logos.SplusObjects.DigitalInput SETBACK_PRESS;
        Crestron.Logos.SplusObjects.DigitalInput RUN;
        Crestron.Logos.SplusObjects.DigitalInput SAVESETBACKENABLE;
        Crestron.Logos.SplusObjects.AnalogInput HEATSETPOINT;
        Crestron.Logos.SplusObjects.AnalogInput COOLSETPOINT;
        Crestron.Logos.SplusObjects.AnalogInput AUTO1PTSETPOINT;
        Crestron.Logos.SplusObjects.AnalogInput DEADBAND;
        Crestron.Logos.SplusObjects.AnalogOutput HEATSETPOINTOUT;
        Crestron.Logos.SplusObjects.AnalogOutput COOLSETPOINTOUT;
        Crestron.Logos.SplusObjects.AnalogOutput AUTO1PTSETPOINTOUT;
        Crestron.Logos.SplusObjects.DigitalOutput SETBACKENABLED;
        UShortParameter HEATSETBACK;
        UShortParameter COOLSETBACK;
        UShortParameter AUTO1PTSETBACK;
        UShortParameter DISPLAYUNIT;
        UShortParameter INSTANCEID;
        StringParameter FILEPATH__DOLLAR__;
        ushort HEAT = 0;
        ushort COOL = 0;
        ushort AUTO1PT = 0;
        ushort SETBKENABLED = 0;
        ushort OLDHEAT = 0;
        ushort OLDCOOL = 0;
        ushort OLDAUTO1PT = 0;
        CrestronString FILENAME;
        private ushort FTOC (  SplusExecutionContext __context__, ushort F ) 
            { 
            
            __context__.SourceCodeLine = 75;
            return (ushort)( (((((F - 320) * 5) / 9) / 10) * 10)) ; 
            
            }
            
        private ushort CTOF (  SplusExecutionContext __context__, ushort C ) 
            { 
            
            __context__.SourceCodeLine = 81;
            return (ushort)( (((((C * 9) / 5) + 320) / 10) * 10)) ; 
            
            }
            
        private void WRITESETPOINTS (  SplusExecutionContext __context__ ) 
            { 
            short FILEHANDLE = 0;
            
            FILE_INFO FILEINFO;
            FILEINFO  = new FILE_INFO();
            FILEINFO .PopulateDefaults();
            
            
            __context__.SourceCodeLine = 92;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 94;
            FILEHANDLE = (short) ( FileOpen( FILENAME ,(ushort) (((1 | 256) | 512) | 32768) ) ) ; 
            __context__.SourceCodeLine = 96;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FILEHANDLE >= 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 99;
                WriteInteger (  (short) ( FILEHANDLE ) ,  (ushort) ( HEAT ) ) ; 
                __context__.SourceCodeLine = 100;
                WriteInteger (  (short) ( FILEHANDLE ) ,  (ushort) ( COOL ) ) ; 
                __context__.SourceCodeLine = 101;
                WriteInteger (  (short) ( FILEHANDLE ) ,  (ushort) ( AUTO1PT ) ) ; 
                __context__.SourceCodeLine = 102;
                WriteInteger (  (short) ( FILEHANDLE ) ,  (ushort) ( SETBKENABLED ) ) ; 
                __context__.SourceCodeLine = 104;
                
                } 
            
            else 
                {
                __context__.SourceCodeLine = 110;
                
                }
            
            __context__.SourceCodeLine = 114;
            FileClose (  (short) ( FILEHANDLE ) ) ; 
            __context__.SourceCodeLine = 116;
            EndFileOperations ( ) ; 
            
            }
            
        private void ENTERSETBACK (  SplusExecutionContext __context__ ) 
            { 
            ushort SETHEAT = 0;
            ushort SETCOOL = 0;
            ushort SETAUTO1PT = 0;
            
            
            __context__.SourceCodeLine = 123;
            
            __context__.SourceCodeLine = 126;
            if ( Functions.TestForTrue  ( ( Functions.Not( SETBACKENABLED  .Value ))  ) ) 
                { 
                __context__.SourceCodeLine = 129;
                HEAT = (ushort) ( HEATSETPOINT  .UshortValue ) ; 
                __context__.SourceCodeLine = 130;
                COOL = (ushort) ( COOLSETPOINT  .UshortValue ) ; 
                __context__.SourceCodeLine = 131;
                AUTO1PT = (ushort) ( AUTO1PTSETPOINT  .UshortValue ) ; 
                __context__.SourceCodeLine = 134;
                SETHEAT = (ushort) ( HEATSETBACK  .Value ) ; 
                __context__.SourceCodeLine = 135;
                SETCOOL = (ushort) ( COOLSETBACK  .Value ) ; 
                __context__.SourceCodeLine = 136;
                SETAUTO1PT = (ushort) ( AUTO1PTSETBACK  .Value ) ; 
                __context__.SourceCodeLine = 140;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (DISPLAYUNIT  .Value == 70) ) && Functions.TestForTrue ( Functions.BoolToInt (INDEGC  .Value == 1) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 141;
                    SETHEAT = (ushort) ( FTOC( __context__ , (ushort)( SETHEAT ) ) ) ; 
                    __context__.SourceCodeLine = 142;
                    SETCOOL = (ushort) ( FTOC( __context__ , (ushort)( SETCOOL ) ) ) ; 
                    __context__.SourceCodeLine = 143;
                    SETAUTO1PT = (ushort) ( FTOC( __context__ , (ushort)( SETAUTO1PT ) ) ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 144;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (DISPLAYUNIT  .Value == 67) ) && Functions.TestForTrue ( Functions.BoolToInt (INDEGF  .Value == 1) )) ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 145;
                        SETHEAT = (ushort) ( CTOF( __context__ , (ushort)( SETHEAT ) ) ) ; 
                        __context__.SourceCodeLine = 146;
                        SETCOOL = (ushort) ( CTOF( __context__ , (ushort)( SETCOOL ) ) ) ; 
                        __context__.SourceCodeLine = 147;
                        SETAUTO1PT = (ushort) ( CTOF( __context__ , (ushort)( SETAUTO1PT ) ) ) ; 
                        } 
                    
                    }
                
                __context__.SourceCodeLine = 150;
                
                __context__.SourceCodeLine = 159;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( COOLSETPOINTOUT  .Value < (SETHEAT + DEADBAND  .UshortValue) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 160;
                    COOLSETPOINTOUT  .Value = (ushort) ( SETCOOL ) ; 
                    __context__.SourceCodeLine = 161;
                    Functions.Delay (  (int) ( 1 ) ) ; 
                    __context__.SourceCodeLine = 162;
                    HEATSETPOINTOUT  .Value = (ushort) ( SETHEAT ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 164;
                    HEATSETPOINTOUT  .Value = (ushort) ( SETHEAT ) ; 
                    __context__.SourceCodeLine = 165;
                    Functions.Delay (  (int) ( 1 ) ) ; 
                    __context__.SourceCodeLine = 166;
                    COOLSETPOINTOUT  .Value = (ushort) ( SETCOOL ) ; 
                    } 
                
                __context__.SourceCodeLine = 169;
                AUTO1PTSETPOINTOUT  .Value = (ushort) ( SETAUTO1PT ) ; 
                __context__.SourceCodeLine = 171;
                SETBACKENABLED  .Value = (ushort) ( 1 ) ; 
                } 
            
            
            }
            
        private void READSETPOINTS (  SplusExecutionContext __context__ ) 
            { 
            short FILEHANDLE = 0;
            short ERRORCODE = 0;
            
            ushort I = 0;
            
            ushort [] VALUE;
            VALUE  = new ushort[ 5 ];
            
            
            __context__.SourceCodeLine = 181;
            StartFileOperations ( ) ; 
            __context__.SourceCodeLine = 183;
            FILEHANDLE = (short) ( FileOpen( FILENAME ,(ushort) (0 | 32768) ) ) ; 
            __context__.SourceCodeLine = 184;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FILEHANDLE >= 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 186;
                ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                ushort __FN_FOREND_VAL__1 = (ushort)4; 
                int __FN_FORSTEP_VAL__1 = (int)1; 
                for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                    { 
                    __context__.SourceCodeLine = 188;
                    ERRORCODE = (short) ( ReadInteger( (short)( FILEHANDLE ) , ref VALUE[ I ] ) ) ; 
                    __context__.SourceCodeLine = 189;
                    
                    __context__.SourceCodeLine = 186;
                    } 
                
                __context__.SourceCodeLine = 196;
                
                __context__.SourceCodeLine = 199;
                HEAT = (ushort) ( VALUE[ 1 ] ) ; 
                __context__.SourceCodeLine = 200;
                COOL = (ushort) ( VALUE[ 2 ] ) ; 
                __context__.SourceCodeLine = 201;
                AUTO1PT = (ushort) ( VALUE[ 3 ] ) ; 
                __context__.SourceCodeLine = 202;
                SETBKENABLED = (ushort) ( VALUE[ 4 ] ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 206;
                
                } 
            
            __context__.SourceCodeLine = 211;
            FileClose (  (short) ( FILEHANDLE ) ) ; 
            __context__.SourceCodeLine = 212;
            EndFileOperations ( ) ; 
            
            }
            
        private void EXITSETBACK (  SplusExecutionContext __context__ ) 
            { 
            ushort SETHEAT = 0;
            ushort SETCOOL = 0;
            ushort SETAUTO1PT = 0;
            
            
            __context__.SourceCodeLine = 221;
            
            __context__.SourceCodeLine = 224;
            if ( Functions.TestForTrue  ( ( SETBACKENABLED  .Value)  ) ) 
                { 
                __context__.SourceCodeLine = 226;
                READSETPOINTS (  __context__  ) ; 
                __context__.SourceCodeLine = 228;
                SETBKENABLED = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 249;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( COOLSETBACK  .Value < (HEAT + DEADBAND  .UshortValue) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 250;
                    COOLSETPOINTOUT  .Value = (ushort) ( COOL ) ; 
                    __context__.SourceCodeLine = 251;
                    Functions.Delay (  (int) ( 1 ) ) ; 
                    __context__.SourceCodeLine = 252;
                    HEATSETPOINTOUT  .Value = (ushort) ( HEAT ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 254;
                    HEATSETPOINTOUT  .Value = (ushort) ( HEAT ) ; 
                    __context__.SourceCodeLine = 255;
                    Functions.Delay (  (int) ( 1 ) ) ; 
                    __context__.SourceCodeLine = 256;
                    COOLSETPOINTOUT  .Value = (ushort) ( COOL ) ; 
                    } 
                
                __context__.SourceCodeLine = 259;
                AUTO1PTSETPOINTOUT  .Value = (ushort) ( AUTO1PT ) ; 
                __context__.SourceCodeLine = 261;
                
                __context__.SourceCodeLine = 266;
                WRITESETPOINTS (  __context__  ) ; 
                __context__.SourceCodeLine = 267;
                SETBACKENABLED  .Value = (ushort) ( 0 ) ; 
                } 
            
            
            }
            
        object SAVESETBACKENABLE_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 279;
                
                __context__.SourceCodeLine = 282;
                SETBKENABLED = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 284;
                WRITESETPOINTS (  __context__  ) ; 
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object SETBACK_PRESS_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 289;
            ENTERSETBACK (  __context__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object RUN_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 294;
        EXITSETBACK (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HEATSETPOINT_OnChange_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 302;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (HEATSETPOINT  .UshortValue == OLDHEAT) ) && Functions.TestForTrue ( Functions.BoolToInt (COOLSETPOINT  .UshortValue == OLDCOOL) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (AUTO1PTSETPOINT  .UshortValue == OLDAUTO1PT) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 304;
            return  this ; 
            } 
        
        __context__.SourceCodeLine = 307;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (HEATSETPOINT  .UshortValue != 0) ) && Functions.TestForTrue ( Functions.BoolToInt (COOLSETPOINT  .UshortValue != 0) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt (AUTO1PTSETPOINT  .UshortValue != 0) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 309;
            OLDHEAT = (ushort) ( HEATSETPOINT  .UshortValue ) ; 
            __context__.SourceCodeLine = 310;
            OLDCOOL = (ushort) ( COOLSETPOINT  .UshortValue ) ; 
            __context__.SourceCodeLine = 311;
            OLDAUTO1PT = (ushort) ( AUTO1PTSETPOINT  .UshortValue ) ; 
            __context__.SourceCodeLine = 312;
            if ( Functions.TestForTrue  ( ( SETBKENABLED)  ) ) 
                { 
                __context__.SourceCodeLine = 314;
                
                __context__.SourceCodeLine = 317;
                SETBKENABLED = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 318;
                SETBACKENABLED  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 319;
                WRITESETPOINTS (  __context__  ) ; 
                } 
            
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 332;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 334;
        FILENAME  .UpdateValue ( FILEPATH__DOLLAR__ + "setback_" + Functions.ItoA (  (int) ( INSTANCEID  .Value ) ) + ".dat"  ) ; 
        __context__.SourceCodeLine = 338;
        READSETPOINTS (  __context__  ) ; 
        __context__.SourceCodeLine = 339;
        SETBACKENABLED  .Value = (ushort) ( SETBKENABLED ) ; 
        __context__.SourceCodeLine = 340;
        if ( Functions.TestForTrue  ( ( SETBACKENABLED  .Value)  ) ) 
            { 
            __context__.SourceCodeLine = 342;
            OLDHEAT = (ushort) ( HEATSETBACK  .Value ) ; 
            __context__.SourceCodeLine = 343;
            OLDCOOL = (ushort) ( COOLSETBACK  .Value ) ; 
            __context__.SourceCodeLine = 344;
            OLDAUTO1PT = (ushort) ( AUTO1PTSETBACK  .Value ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    FILENAME  = new CrestronString( InheritedStringEncoding, 256, this );
    
    INDEGF = new Crestron.Logos.SplusObjects.DigitalInput( INDEGF__DigitalInput__, this );
    m_DigitalInputList.Add( INDEGF__DigitalInput__, INDEGF );
    
    INDEGC = new Crestron.Logos.SplusObjects.DigitalInput( INDEGC__DigitalInput__, this );
    m_DigitalInputList.Add( INDEGC__DigitalInput__, INDEGC );
    
    SETBACK_PRESS = new Crestron.Logos.SplusObjects.DigitalInput( SETBACK_PRESS__DigitalInput__, this );
    m_DigitalInputList.Add( SETBACK_PRESS__DigitalInput__, SETBACK_PRESS );
    
    RUN = new Crestron.Logos.SplusObjects.DigitalInput( RUN__DigitalInput__, this );
    m_DigitalInputList.Add( RUN__DigitalInput__, RUN );
    
    SAVESETBACKENABLE = new Crestron.Logos.SplusObjects.DigitalInput( SAVESETBACKENABLE__DigitalInput__, this );
    m_DigitalInputList.Add( SAVESETBACKENABLE__DigitalInput__, SAVESETBACKENABLE );
    
    SETBACKENABLED = new Crestron.Logos.SplusObjects.DigitalOutput( SETBACKENABLED__DigitalOutput__, this );
    m_DigitalOutputList.Add( SETBACKENABLED__DigitalOutput__, SETBACKENABLED );
    
    HEATSETPOINT = new Crestron.Logos.SplusObjects.AnalogInput( HEATSETPOINT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( HEATSETPOINT__AnalogSerialInput__, HEATSETPOINT );
    
    COOLSETPOINT = new Crestron.Logos.SplusObjects.AnalogInput( COOLSETPOINT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( COOLSETPOINT__AnalogSerialInput__, COOLSETPOINT );
    
    AUTO1PTSETPOINT = new Crestron.Logos.SplusObjects.AnalogInput( AUTO1PTSETPOINT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( AUTO1PTSETPOINT__AnalogSerialInput__, AUTO1PTSETPOINT );
    
    DEADBAND = new Crestron.Logos.SplusObjects.AnalogInput( DEADBAND__AnalogSerialInput__, this );
    m_AnalogInputList.Add( DEADBAND__AnalogSerialInput__, DEADBAND );
    
    HEATSETPOINTOUT = new Crestron.Logos.SplusObjects.AnalogOutput( HEATSETPOINTOUT__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( HEATSETPOINTOUT__AnalogSerialOutput__, HEATSETPOINTOUT );
    
    COOLSETPOINTOUT = new Crestron.Logos.SplusObjects.AnalogOutput( COOLSETPOINTOUT__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( COOLSETPOINTOUT__AnalogSerialOutput__, COOLSETPOINTOUT );
    
    AUTO1PTSETPOINTOUT = new Crestron.Logos.SplusObjects.AnalogOutput( AUTO1PTSETPOINTOUT__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( AUTO1PTSETPOINTOUT__AnalogSerialOutput__, AUTO1PTSETPOINTOUT );
    
    HEATSETBACK = new UShortParameter( HEATSETBACK__Parameter__, this );
    m_ParameterList.Add( HEATSETBACK__Parameter__, HEATSETBACK );
    
    COOLSETBACK = new UShortParameter( COOLSETBACK__Parameter__, this );
    m_ParameterList.Add( COOLSETBACK__Parameter__, COOLSETBACK );
    
    AUTO1PTSETBACK = new UShortParameter( AUTO1PTSETBACK__Parameter__, this );
    m_ParameterList.Add( AUTO1PTSETBACK__Parameter__, AUTO1PTSETBACK );
    
    DISPLAYUNIT = new UShortParameter( DISPLAYUNIT__Parameter__, this );
    m_ParameterList.Add( DISPLAYUNIT__Parameter__, DISPLAYUNIT );
    
    INSTANCEID = new UShortParameter( INSTANCEID__Parameter__, this );
    m_ParameterList.Add( INSTANCEID__Parameter__, INSTANCEID );
    
    FILEPATH__DOLLAR__ = new StringParameter( FILEPATH__DOLLAR____Parameter__, this );
    m_ParameterList.Add( FILEPATH__DOLLAR____Parameter__, FILEPATH__DOLLAR__ );
    
    
    SAVESETBACKENABLE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SAVESETBACKENABLE_OnPush_0, false ) );
    SETBACK_PRESS.OnDigitalPush.Add( new InputChangeHandlerWrapper( SETBACK_PRESS_OnPush_1, false ) );
    RUN.OnDigitalPush.Add( new InputChangeHandlerWrapper( RUN_OnPush_2, false ) );
    HEATSETPOINT.OnAnalogChange.Add( new InputChangeHandlerWrapper( HEATSETPOINT_OnChange_3, false ) );
    COOLSETPOINT.OnAnalogChange.Add( new InputChangeHandlerWrapper( HEATSETPOINT_OnChange_3, false ) );
    AUTO1PTSETPOINT.OnAnalogChange.Add( new InputChangeHandlerWrapper( HEATSETPOINT_OnChange_3, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_TSTATEX_SETBACK ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint INDEGF__DigitalInput__ = 0;
const uint INDEGC__DigitalInput__ = 1;
const uint SETBACK_PRESS__DigitalInput__ = 2;
const uint RUN__DigitalInput__ = 3;
const uint SAVESETBACKENABLE__DigitalInput__ = 4;
const uint HEATSETPOINT__AnalogSerialInput__ = 0;
const uint COOLSETPOINT__AnalogSerialInput__ = 1;
const uint AUTO1PTSETPOINT__AnalogSerialInput__ = 2;
const uint DEADBAND__AnalogSerialInput__ = 3;
const uint HEATSETPOINTOUT__AnalogSerialOutput__ = 0;
const uint COOLSETPOINTOUT__AnalogSerialOutput__ = 1;
const uint AUTO1PTSETPOINTOUT__AnalogSerialOutput__ = 2;
const uint SETBACKENABLED__DigitalOutput__ = 0;
const uint HEATSETBACK__Parameter__ = 10;
const uint COOLSETBACK__Parameter__ = 11;
const uint AUTO1PTSETBACK__Parameter__ = 12;
const uint DISPLAYUNIT__Parameter__ = 13;
const uint INSTANCEID__Parameter__ = 14;
const uint FILEPATH__DOLLAR____Parameter__ = 15;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
